<template>
    <nav class="pb-5"> <!---->
        <div class="navigation-box">

            <ul class="nav justify-content-center">
                <li class="nav-item">
                    <button href="#" @click="getAllSoliders" class="btn btn-light nav-link text-dark">{{allGrade}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getSoliderByGrade(gradeElev)" class="btn btn-light nav-link text-dark">{{gradeElev}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getSoliderByGrade(gradeOffiser)" class="btn btn-light nav-link text-dark">{{gradeOffiser}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getSoliderByGrade(gradeMannskap)" class="btn btn-light nav-link text-dark">{{gradeMannskap}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getSoliderByGrade(gradeSpecialist)" class="btn btn-light nav-link text-dark">{{gradeSpecialist}}</button>
               </li>
            </ul>
        </div>
    </nav>
    <div class="table-solider table-responsive-md p-4 bg-primary">
        <table class="table table-hover" v-if="checkElev.clicked">
            <thead>
                <tr>
                <th scope="col">#ID</th>
                <th scope="col">Fornavn</th>
                <th scope="col">Etternavn</th>
                <th scope="col">Fødselsdato</th>
                <th scope="col">Grad</th>
                <th scope="col">Rangering</th>
                </tr>
            </thead>
           
            <list-solider-item 
                v-for="(solider, i) in soliderOut[1]"
                :key="i"
                :id="solider.id"
                :firstName="solider.firstName"
                :lastName="solider.lastName"
                :birthdate="solider.birthdate"
                :grade="solider.grade"
                :ranking="solider.ranking"
            ></list-solider-item>

        </table>

        <table class="table table-hover"  v-if="checkAll.clicked">
            <thead>
                <tr>
                    <th scope="col">#ID</th>
                    <th scope="col">Fornavn</th>
                    <th scope="col">Etternavn</th>
                    <th scope="col">Fødselsdato</th>
                    <th scope="col">Grad</th>
                    <th scope="col">Rangering</th>
                </tr>
            </thead>
           
            <list-solider-item 
                v-for="(solider, i) in soliders"
                :v-if="checkElev.clicked"
                :key="i"
                :id="solider.id"
                :firstName="solider.firstName"
                :lastName="solider.lastName"
                :birthdate="solider.birthdate"
                :grade="solider.grade"
                :ranking="solider.ranking"
            ></list-solider-item>
        </table>   
    </div>
</template>


<script>
import soliderService from "../../services/solider/soliderService.js"
import ListSoliderItem from './ListSoliderItem.vue';
import { reactive, ref } from 'vue'

export default {
    setup() {
        const soliders = soliderService.getAllSoliders();
        const allGrade = ref("Alle");

        const gradeElev = ref("Elev");
        const gradeOffiser = ref("Offiser");
        const gradeMannskap = ref("Mannskap");
        const gradeSpecialist = ref("Spesialist");
       
        
        /* KONTROLLERER OUPUT BASERT PÅ KNAPPENE */
        const checkElev = reactive({
            clicked: false
        })

         const checkAll = reactive({
            clicked: true
        })

       /* SKRIVER UT ALLE SOLDATER */
         const getAllSoliders = async () => {
            checkAll.clicked = true;
            checkElev.clicked = false;

            return soliders
        }
        
        /* SKRIVER UT SOLDAT BASERT PÅ VALGT GRAD*/
        let soliderOut = ref ([""])
        
        const getSoliderByGrade = async (grade) => {
            //const soliders = soldierService.getAllSoliders();
            soliderOut.value.splice(1);
            checkElev.clicked = true;
            checkAll.clicked = false;
           
            let soliderGrade = await soliderService.getSoliderByGrade(grade);
            soliderOut.value.push ( soliderGrade )

            console.log(checkAll)
            return soliderOut
        }


        return {
            getAllSoliders, getSoliderByGrade,
            gradeElev, soliderOut, gradeOffiser, gradeMannskap, gradeSpecialist,
            allGrade, soliders,
            checkElev, checkAll, 
        }
    
    },

    components: {
        ListSoliderItem,  
    }
}
</script>

<style>
    .table-solider {
        border-radius: 8px;
        border: 1px solid #DED9D2 ;
        margin-bottom: 30px;
    }
</style>