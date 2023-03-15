<template>
        <!-- FINN SOLDAT BASERT PÅ RANG -->
        <nav class="navbar pt-5 mb-2 row"> 
            <div class="navigation-box">
                <ul class="nav filter-list-card-nav justify-content-center">

                    <li class="nav-item col-5"> 
                        <button type="button" @click="allWeaponsList" class="btn bg-primary btn-filter nav-link text-dark">Liste med våpen</button>
                    </li>
                    <li class="nav-item col-5"> 
                        <button type="button" @click="allWeaponsCard" class="btn bg-primary btn-filter nav-link text-dark">Info om våpen</button>
                    </li>
                     
                </ul>
            </div>
        </nav>
    

    <!-- SØK, LEGG TIL ELLER ENDRE SOLDATER -->
    <section>
        <div class="input-group mb-5 ">
            
            <input v-model="inputName" type="text" class="form-control" placeholder="Søk etter våpen" aria-label="Søk etter våpem" aria-describedby="basic-addon2">
            <div class="input-group-append col-3" >
                <button @click="getWeaponName" class="btn p-2 btn-secondary" type="button">Søk etter våpen
                    <i class="bi bi-search"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="addWeaponFunction" type="button" class="btn btn-do-something btn-primary">Nytt våpen
                    <i class="bi bi-plus-circle"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="changeWeapon" class="btn btn-do-something btn-secondary" type="button">Endre våpen
                    <i class="bi bi-arrow-repeat"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="deleteWeapon" class="btn btn-do-something btn-secondary" type="button">Slett våpen
                    <i class="bi bi-x-circle"></i>
                </button>
            </div>

        </div>
    </section>


    <!-- SKJEMA ENDRE ELLER LEGG TIL SOLDAT -->
    <add-weapon  v-if="checkAdd.clicked"></add-weapon>
    <change-weapon v-if="checkChange.clicked"></change-weapon>
    <delete-weapon v-if="checkDelete.clicked"></delete-weapon>
    
    <!--Gir skjemaene avbryt knapp -->
    <div v-if="checkExit.clicked" class="row justify-content-center">
        <div class="col-2 mb-5 mt-2">
            <button @click="exitAction" type="button" class="btn btn-primary btn-lg">
                Avbryt <i class="bi bi-x-circle"></i>
            </button>
        </div>
    </div>


    <!-- OUTPUT SØK ETTER SOLDATER, ELLER KNAPP TIL KORT ELLER LISTE -->
    <section class="row" v-if="checkNameOut.clicked">
        <weapon-item 
            v-for="(weapon, i) in weaponNameOut[1]"
            :key="i"
            :id="weapon.id"
            :name="weapon.name"
            :type="weapon.type"
            :image="weapon.image"
            :magazinSize="weapon.magazinSize"
        ></weapon-item>
    </section>
    
    <section class="row" v-if="checkBtnCard.clicked">
        <h3 class="text-center"> ALLE VÅPEN </h3>
        <section>
            <weapon-type-navigation></weapon-type-navigation>
        </section>
    </section>

    <section class="row" v-if="checkBtnList.clicked">
        <h3 class="text-center"> LISTE MED ALLE VÅPEN </h3>
        <section>
            <list-weapon-list></list-weapon-list>
        </section>  
    </section>

</template>


<script>
import AddWeapon from "./AddWeapon.vue"
import { reactive, ref } from 'vue'
import weaponService from '../../services/weapon/weaponService.js'
import changeWeapon from "./ChangeWeapon.vue"
import ListWeaponList from './ListWeaponList.vue'
import WeaponItem from './WeaponItem.vue'
import DeleteWeapon from './DeleteWeapon.vue'
import WeaponTypeNavigation from './WeaponTypeNavigation.vue'

export default {
    setup() {
        const weapons = weaponService.getAllWeapons();

        const inputName = ref(inputName);

        /* SOLDATER VIST I KORT */
         const checkBtnCard = reactive({
            clicked: false
        })
        const allWeaponsCard = () => {
            checkBtnCard.clicked = true;
            checkBtnList.clicked = false;
        }

        /* SOLDATER VIST I LISTE */
         const checkBtnList = reactive({
            clicked: true
        })
        const allWeaponsList = () => {
            checkBtnList.clicked = true;
            checkBtnCard.clicked = false;
        }
      
        /* LEGG TIL SOLDAT */
        const checkAdd = reactive({
            clicked: false
        })
        const addWeaponFunction = () => {
            checkExit.clicked = true
            checkAdd.clicked = true
            checkChange.clicked = false
            checkNameOut.clicked = false
            checkDelete.clicked = false
        }

        /* ENDRE SOLDAT */
        const checkChange = reactive({
            clicked: false
        })
        const changeWeapon = () => {
            checkExit.clicked = true
            checkChange.clicked = true
            checkAdd.clicked = false
            checkNameOut.clicked = false
            checkDelete.clicked = false
        };

        /* SLETTE SOLDAT */
        const checkDelete = reactive({
            clicked: false
        })
        const deleteWeapon = () => {
            checkExit.clicked = true
            checkDelete.clicked = true
            checkChange.clicked = false
            checkAdd.clicked = false
            checkNameOut.clicked = false;
        };

        /* SØK ETTER SOLDAT */
        const checkNameOut = reactive({
            clicked: false
        })
       

        let weaponNameOut = ref ([""])
        const getWeaponName = async () => { 
            checkNameOut.clicked = true;

            weaponNameOut.value.splice(1)

            let WeaponName = await weaponService.getWeaponByName(inputName.value);
            weaponNameOut.value.push ( WeaponName )
           
            return weaponNameOut
        }

        const checkExit = reactive({
            clicked: false,
        })

        const exitAction = () => {
            alert ("Du avbryter nå handlingen din, og dine endringer blir avbrutt")
            checkDelete.clicked = false
            checkChange.clicked = false
            checkAdd.clicked = false
            checkExit.clicked = false
        }

        return {
            addWeaponFunction, checkChange, checkAdd, checkDelete,
            checkBtnCard, checkBtnList, weapons, weaponService,
            allWeaponsCard, allWeaponsList, 
            changeWeapon, getWeaponName,
            inputName, weaponNameOut, deleteWeapon, checkNameOut, 
            exitAction, checkExit
        }
    },
    
       components: {
        AddWeapon, changeWeapon,
        ListWeaponList, WeaponItem, DeleteWeapon,
        WeaponTypeNavigation
    }
}
</script>

<style>
    .btn-do-something{
        padding-top: 8px;
        padding-bottom: 8px;
        border-radius: 30px;
        margin: auto;
        width: 90%;
    }
    .filter-list-card-nav {
        position: absolute;
        right: 10px;
        top: -20px;
    }
    .btn-filter{
        border-radius: 10px;
        margin-left: 10px;
    }
</style>

