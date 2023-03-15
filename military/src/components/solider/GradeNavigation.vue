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

    <!-- OUTPUT ALLE -->
    <section class="row" v-if="checkAll.clicked">
        <solider-item 
            v-for="(solider, i) in soliders"
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

    <!-- OUTPUT BASERT PÅ SØK -->
    <section class="row" v-if="checkElev.clicked">
        <solider-item 
            v-for="(solider, i) in soliderOut[1]"
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

</template>

<script>
import { reactive, ref } from 'vue'
import soldierService from "../../services/solider/soliderService.js"
import SoliderItem from "./SoliderItem.vue"

export default {
    setup() {

        const soliders = soldierService.getAllSoliders();
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
           
            let soliderGrade = await soldierService.getSoliderByGrade(grade);
            soliderOut.value.push ( soliderGrade )

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
        SoliderItem
    }
    
}
</script>


