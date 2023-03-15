<template>
    <section class="row">
        
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
</template>

<script>
import SoliderItem from "./SoliderItem.vue"
import soliderService from "../../services/solider/soliderService.js"

export default {
    setup() {
        const soliders = soliderService.getAllSoliders();
        
        return {
            soliders, 
        }
    },

    components: {
        SoliderItem,
    }
}
</script>