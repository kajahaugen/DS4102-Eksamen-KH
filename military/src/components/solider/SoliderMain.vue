<template>
    <!-- FINN SOLDAT BASERT PÅ RANG -->
    <nav class="navbar pt-5 mb-2 row"> 
        <div class="navigation-box">
            <ul class="nav filter-list-card-nav justify-content-center">

                <li class="nav-item col-5"> 
                    <button type="button" @click="allSolidersList" class="btn bg-primary btn-filter nav-link text-dark">Liste med soldater</button>
                </li>
                <li class="nav-item col-5"> 
                    <button type="button" @click="allSolidersCard" class="btn btn-primary btn-filter nav-link text-dark">Info om soldater</button>
                </li>
                     
            </ul>
        </div>
    </nav>

    <!-- SØK, LEGG TIL ELLER ENDRE SOLDATER -->
    <section>
        <div class="input-group mb-5 ">
            
            <input v-model="inputName" type="text" class="form-control" placeholder="Søk etter fornavn til soldat" aria-label="Søk etter soldat" aria-describedby="basic-addon2">
            <div class="input-group-append col-3" >
                <button @click="getSoliderFirstName" class="btn p-2 btn-secondary" type="button">Søk etter soldat
                    <i class="bi bi-search"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="addSoliderFunction" type="button" class="btn btn-do-something btn-primary">Ny soldat
                    <i class="bi bi-plus-circle"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="changeSolider" class="btn btn-do-something btn-secondary" type="button">Endre soldat
                    <i class="bi bi-arrow-repeat"></i>
                </button>
            </div>
            <div class="input-group-append col-2">
                <button @click="deleteSolider" class="btn btn-do-something btn-secondary" type="button">Slett soldat
                    <i class="bi bi-x-circle"></i>
                </button>
            </div>

        </div>
    </section>

    <!-- SKJEMA ENDRE ELLER LEGG TIL SOLDAT -->
    <add-solider  v-if="checkAdd.clicked"></add-solider>
    <change-solider v-if="checkChange.clicked"></change-solider>
    <delete-solider v-if="checkDelete.clicked"></delete-solider>

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
        <solider-item 
            v-for="(solider, i) in soliderNameOut[1]"
            :key="i"
            :firstName="solider.firstName"
            :lastName="solider.lastName"
            :image="solider.image"
            :birthdate="solider.birthdate"
            :grade="solider.grade"
            :ranking="solider.ranking"
            :outOnMission="solider.outOnMission"
            :missionName="solider.missionName"
        ></solider-item>
    </section>
    
    <section class="row" v-if="checkBtnCard.clicked">
        <h3 class="text-center"> ALLE SOLDATER </h3>
        <grade-navigation></grade-navigation>
    </section>

    <section class="row" v-if="checkBtnList.clicked">
        <h3 class="text-center"> LISTE MED ALLE SOLDATER </h3>
        <list-solider-list></list-solider-list>
    </section>

</template>


<script>
import AddSolider from "./AddSolider.vue"
import { reactive, ref } from 'vue'
import soldierService from '../../services/solider/soliderService'
import changeSolider from "./ChangeSolider.vue"
import ListSoliderList from './ListSoliderList.vue'
import SoliderItem from './SoliderItem.vue'
import DeleteSolider from './DeleteSolider.vue'
import GradeNavigation from './GradeNavigation.vue'

export default {
    setup() {
        const soliders = soldierService.getAllSoliders();

        const inputName = ref(inputName);

        /* SOLDATER VIST I KORT */
         const checkBtnCard = reactive({
            clicked: false
        })
        const allSolidersCard = () => {
            checkBtnCard.clicked = true;
            checkBtnList.clicked = false;
        }

        /* SOLDATER VIST I LISTE */
         const checkBtnList = reactive({
            clicked: true
        })
        const allSolidersList = () => {
            checkBtnList.clicked = true;
            checkBtnCard.clicked = false;
        }
      
        /* LEGG TIL SOLDAT */
        const checkAdd = reactive({
            clicked: false
        })
        const addSoliderFunction = () => {
            checkExit.clicked = true
            checkAdd.clicked = true
            checkChange.clicked = false
            checkDelete.clicked = false
        }

        /* ENDRE SOLDAT */
        const checkChange = reactive({
            clicked: false
        })
        const changeSolider = () => {
            checkExit.clicked = true
            checkChange.clicked = true
            checkAdd.clicked = false
            checkDelete.clicked = false
        };

        /* SLETTE SOLDAT */
        const checkDelete = reactive({
            clicked: false
        })
        const deleteSolider = () => {
            checkExit.clicked = true
            checkDelete.clicked = true
            checkChange.clicked = false
            checkAdd.clicked = false
        };

        /* SØK ETTER SOLDAT */
        const checkNameOut = reactive({
            clicked: false
        })
       

        let soliderNameOut = ref ([""])
        const getSoliderFirstName = async () => { 
            checkNameOut.clicked =true;

            soliderNameOut.value.splice(1)

            let soliderName = await soldierService.getSoliderByFirstName(inputName.value);
            soliderNameOut.value.push ( soliderName )
           
            return soliderNameOut
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
            addSoliderFunction, checkChange, checkAdd, checkDelete,
            checkBtnCard, checkBtnList, soliders, 
            allSolidersCard, allSolidersList, 
            changeSolider, getSoliderFirstName,
            inputName, soliderNameOut, deleteSolider, checkNameOut, 
            exitAction, checkExit
        }
    },
    
       components: {
        AddSolider, changeSolider,
              ListSoliderList, SoliderItem,
              DeleteSolider,
              GradeNavigation
    }
}
</script>

<style>
    .btn-do-something{
        padding-top: 8px;
        padding-bottom: 8px;
        border-radius: 30px;
        margin: auto;
        width: 100%;
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

