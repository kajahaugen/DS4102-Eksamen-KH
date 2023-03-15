<template>
    <div>        
        <section class="row">
            <form class="col-xl-5 col-lg-6 col-md-12 p-4 add-solider-form bg-primary">
                
                <h4 class="text-center mb-4">Legg til soldat </h4>

                <div class="form-group row">
                     <section class="bg-white add-image p-3 mb-4">
                        <h2>Last opp bilde</h2>

                        <div class="row">
                            <div class="col-12">
                                <input @change="setImage" class="form-control" type="file"> <!-- @change="setImage" (e) innholder informasjon og data-->
                            </div>
                        </div>

                    </section>   
                    <div class="col-6">
                        <label for="firstname">Fornavn</label>
                        <input v-model="inputFirstName" type="text" class="form-control" placeholder="Kari">
                    </div>
                    <div class="col-6">
                        <label for="lastname">Etternavn</label>
                        <input v-model="inputLastName" type="text" class="form-control" placeholder="Nordmann">
                    </div>
                </div>
                <div class="form-group">
                    <label for="birthdate">Fødselsdato</label>
                    <input v-model="inputBirthdate" type="text" class="form-control" placeholder="10.Mars.1990">
                </div>
                <div class="form-group mt-3">
                    <label for="grade">Rangeringsgrad</label>
                    <select v-model="selected" class="form-control">
                        <option>Elev</option>
                        <option>Offiser</option>
                        <option>Spesialist</option>
                        <option>Mannskap</option>
                        <option>Offiser</option>
                    </select>
                </div>
                <div class="form-group  mt-1">
                    <label for="ranking">Rangering</label>
                    <input v-model="inputRanking" type="text" class="form-control" placeholder="F.eks: Kadett">
                </div>
                <div class="form-group mt-3">
                    <label for="exampleFormControlSelect1">Er soldat ute på oppdrag?</label>
                    <button @click="checkedYes" type="button" class="btn btn-add-solider btn-secondary"> Ja </button>
                    <button @click="checkedNo" type="button" class="btn btn-add-solider btn-secondary"> Nei </button>
                </div>
                <div v-if="clickYes.clicked">
                    <div class="form-group  mt-1">
                        <label for="missionName">Oppdrag</label>
                        <input  v-model="inputMissionName" type="text" class="form-control" placeholder="Oppdragets navn">
                    </div>
                </div>
                <div v-if="clickNo.clicked">
                    <p></p>
                </div>  
                <div class="form-group add-solider mt-4">
                    <button @click="AddSolider" type="button" class="btn btn-add-solider btn-secondary"> Legg til Soldat</button>
                </div>

            </form>
        </section>

    </div>
</template>

<script>
import soliderService from "../../services/solider/soliderService.js"
import {reactive, ref} from '@vue/reactivity'

export default {
    setup() {

    /* KNAPPER */
    const clickYes = reactive({
        clicked: false
    })
    const clickNo = reactive({
        clicked: false
    })
    const checkedYes = () => {
        clickYes.clicked = true
        clickNo.clicked = false
    }
    const checkedNo = () => {
        clickNo.clicked = true
        clickYes.clicked = false
    }

    /* INPUT FRA BRUKER */
    const soliders = soliderService.getAllSoliders();
    const inputFirstName = ref(inputFirstName);
    const inputLastName = ref(inputLastName);
    const inputImage = ref(inputImage);
    const inputBirthdate = ref(inputBirthdate);
    const selected = ref(selected);
    const inputRanking = ref(inputRanking);
    const inputOutOnMission = ref(true);
    const inputMissionName = ref(inputMissionName);


    /* SOLDAT OBJEKT GJØRES KLART */
    const newSolider = ref (
        { firstName: inputFirstName, lastName: inputLastName,  image: inputImage, birthdate: inputBirthdate, grade: selected, ranking: inputRanking, outOnMission: inputOutOnMission, missionName: inputMissionName },
    );

    /* BILDE */
    const image = new FormData();
        
    const setImage = (e) => {
        image.append("file", e.target.files[0]);
        newSolider.value.image = e.target.files[0].name;
    }  

    /* SOLDAT LEGGES TIL OG PUBLISERES */
    const AddSolider = () => { 
        soliderService.postImageSolider( newSolider.value, image )
        alert("Din Soldat er nå lagt til")
    }
            
    return {
        checkedYes, 
        checkedNo, 
        clickYes, clickNo, 
        AddSolider,
        soliders,
        newSolider,
        inputFirstName,
        inputLastName,
        inputImage,
        inputBirthdate,
        selected,
        inputRanking,
        inputOutOnMission,
        inputMissionName,
        setImage,        
        }
    },   
}
</script>

<style>
    .add-solider-form{
        margin: auto;
        width: 70%;
        border: 1px solid #DED9D2;
        border-radius: 6px;
    }

    .add-solider {
        margin: auto;
        width: 30%;
    }

    .btn-add-solider {
        border-radius: 20px;
    }
</style>