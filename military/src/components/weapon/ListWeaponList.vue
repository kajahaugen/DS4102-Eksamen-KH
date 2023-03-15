<template>
    <nav class="pb-5"> <!---->
        <div class="navigation-box">

            <ul class="nav justify-content-center">
                <li class="nav-item">
                    <button href="#" @click="getAllWeapons" class="btn btn-light nav-link text-dark">{{allType}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeSkarpskyttergevær)" class="btn btn-light nav-link text-dark">{{typeSkarpskyttergevær}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeAutomatgevær)" class="btn btn-light nav-link text-dark">{{typeAutomatgevær}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typePanservernvåpen)" class="btn btn-light nav-link text-dark">{{typePanservernvåpen}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeMaskingevær)" class="btn btn-light nav-link text-dark">{{typeMaskingevær}}</button>
               </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeMaskinpistol)" class="btn btn-light nav-link text-dark">{{typeMaskinpistol}}</button>
               </li>
            </ul>
        </div>
    </nav>
    

    <div class="table-Weapon table-responsive-md p-4 bg-primary">
        <table class="table table-hover" v-if="checkType.clicked">
            <thead>
                <tr>
                <th scope="col">#ID</th>
                <th scope="col">Navn</th>
                <th scope="col">Type våpen</th>
                <th scope="col">Magasin størrelse</th>
                </tr>
            </thead>
            <list-weapon-item 
                v-for="(weapon, i) in weaponOut[1]"
                :key="i"
                :id="weapon.id"
                :name="weapon.name"
                :type="weapon.type"
                :image="weapon.image"
                :magazinSize="weapon.magazinSize"
            ></list-weapon-item>
        </table>

        <table class="table table-hover"  v-if="checkAll.clicked">
            <thead>
                <tr>
                <th scope="col">#ID</th>
                <th scope="col">Navn</th>
                <th scope="col">Type våpen</th>
                <th scope="col">Magasin størrelse</th>
                </tr>
            </thead>
            <list-weapon-item 
                v-for="(weapon, i) in weapons"
                :key="i"
                :id="weapon.id"
                :name="weapon.name"
                :type="weapon.type"
                :image="weapon.image"
                :magazinSize="weapon.magazinSize"
            ></list-weapon-item>
        </table> 
    </div>
</template>


<script>
import WeaponService from "../../services/weapon/weaponService.js"
import ListWeaponItem from './ListWeaponItem.vue';
import { reactive, ref } from 'vue'

export default {
    setup() {
        const weapons = WeaponService.getAllWeapons();
        const allType = ref("Alle");

        const typeSkarpskyttergevær = ref("Skarpskyttergevær");
        const typeAutomatgevær = ref("Automatgevær");
        const typePanservernvåpen = ref("Panservernvåpen");
        const typeMaskingevær = ref("Maskingevær");
        const typeMaskinpistol = ref("Maskinpistol");
       
        
        /* KONTROLLERER OUPUT BASERT PÅ KNAPPENE */
        const checkType = reactive({
            clicked: false
        })

         const checkAll = reactive({
            clicked: true
        })

       /* SKRIVER UT ALLE SOLDATER */
         const getAllWeapons = async () => {
            checkAll.clicked = true;
            checkType.clicked = false;

            return weapons
        }
        
        /* SKRIVER UT SOLDAT BASERT PÅ VALGT GRAD*/
        let weaponOut = ref ([""])
        
        const getWeaponByType = async (type) => {
            //const Weapons = soldierService.getAllWeapons();
            weaponOut.value.splice(1);
            checkType.clicked = true;
            checkAll.clicked = false;
          
            let weaponType = await WeaponService.getWeaponByType(type);
            weaponOut.value.push ( weaponType )

            return weaponOut
        }
    

        return {
            getAllWeapons, getWeaponByType, WeaponService,
            typeSkarpskyttergevær, typeAutomatgevær, typePanservernvåpen,typeMaskingevær, typeMaskinpistol,
            allType, weapons, weaponOut,
            checkType, checkAll, 
        }
    
    },

    components: {
        ListWeaponItem,  
    }
}
</script>

<style>
    .table-Weapon {
        border-radius: 8px;
        border: 1px solid #DED9D2 ;
        margin-bottom: 30px;
    }
</style>