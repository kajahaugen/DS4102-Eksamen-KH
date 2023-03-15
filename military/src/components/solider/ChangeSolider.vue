<template>
    <section class="row">

        <form class="col-xl-5 col-lg-6 col-md-12 p-4 add-solider-form bg-primary">
            <div class="form-group row">
                <h4 class="text-center mb-4">Hvilken soldat vil du endre? </h4>
                <div class="col-6">
                    <label for="firstname">Id</label>
                    <input v-model="inputId" type="text" class="form-control" placeholder="Soldats ID">
                    <input @click="getSolider" class="show-chosen" type="button" value="Se Soldat">
                </div>
                <div class="col-6 ">
                    <label for="firstname">Fornavn</label>
                    <input v-model="inputFirstName" type="text" class="form-control" placeholder="Kari">
                    <input @click="getSoliderFirstName" class="show-chosen" type="button" value="Se Soldat">
                </div>
                
                <div class="form-group mt-4 pt-4 see-solider-form">
                    <h4 class="text-center mb-4">Soldat: </h4>
                    <div class="bg-white add-image p-3 mb-4">
                        <h2>Last opp bilde</h2>

                        <div class="row">
                            <div class="col-8">
                                <input @change="setImage" class="form-control" type="file"> <!-- @change="setImage" (e) innholder informasjon og data-->
                            </div>
                            <div class="col-4">
                                <img v-if="clickImg.clicked" class="card-img-top" style="margin-top: -40px; height: 130px; width: 130px; object-fit: cover;" :src="`https://localhost:7295/images/Soliders/${image}`" :alt="`bilde av: ${inputFirstName}`">
                            </div>
                        </div>
                    </div>  
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
              <button @click="saveSoldier" type="button" class="btn btn-add-solider btn-secondary"> Lagre endringer </button>
            </div>
            
        </form>

    </section>
</template>

<script>
import soliderService from "../../services/solider/soliderService.js"
import {reactive, toRefs } from '@vue/reactivity'

export default {
    setup() {

    //KNAPPENE 
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
    const clickImg = reactive({
        clicked: false
    })


    // FÅR TAK I INPUT
    const soliderForm = reactive ({
        inputId: "",
        inputFirstName: "",
        inputLastName: "",
        image: "", 
        inputBirthdate: "",
        selected: "",
        inputRanking: "",
        inputOutOnMission: "",
        inputMissionName: "",
    });

    const soliders = soliderService.getAllSoliders();

    // SKRIVER UT SOLDAT BASERT BASERT PÅ INPUT ID
     const getSolider = async () => { 
        clickImg.clicked = true
        const solider = await soliderService.getSoliderById(soliderForm.inputId);
        
        console.log(solider)
        soliderForm.inputId = solider.id;
        soliderForm.inputFirstName = solider.firstName;  
        soliderForm.inputLastName = solider.lastName;
        soliderForm.image = solider.image;
        soliderForm.inputBirthdate = solider.birthdate;
        soliderForm.selected = solider.grade;
        soliderForm.inputRanking = solider.ranking;
        soliderForm.inputOutOnMission = solider.outOnMission;
        soliderForm.inputMissionName = solider.missionName;  
    }

     // SKRIVER UT SOLDAT BASERT BASERT PÅ INPUT ID
     const getSoliderFirstName = async () => { 
        clickImg.clicked = true
        const soliderName = await soliderService.getSoliderByFirstName(soliderForm.inputFirstName);
        
        soliderForm.inputId = soliderName[0].id;
        soliderForm.inputFirstName = soliderName[0].firstName;  
        soliderForm.inputLastName = soliderName[0].lastName;
        soliderForm.image = soliderName[0].image;
        soliderForm.inputBirthdate = soliderName[0].birthdate;
        soliderForm.selected = soliderName[0].grade;
        soliderForm.inputRanking = soliderName[0].ranking;
        soliderForm.inputOutOnMission = soliderName[0].outOnMission;
        soliderForm.inputMissionName = soliderName[0].missionName;   
    }


    // LAGRER ENDRET SOLDAT ID
    const saveSoldier = async () => {
        let solider = await soliderService.getSoliderById(soliderForm.inputId);
        
        solider.id = soliderForm.inputId,
        solider.firstName = soliderForm.inputFirstName,
        solider.lastName = soliderForm.inputLastName, 
        solider.image = soliderForm.image
        solider.birthdate = soliderForm.inputBirthdate,
        solider.grade = soliderForm.selected,
        solider.ranking = soliderForm.inputRanking,
        solider.outOnMission = clickYes.clicked,
        solider.missionName = soliderForm.inputMissionName, 

        alert("Din soldat er nå blitt endret")
        soliderService.putSolider( solider )
        window.location.reload();
    }

    //BILDE
        const image = new FormData();

        const setImage = (e) => {
            image.append("file", e.target.files[0]);
            soliderForm.image = e.target.files[0].name;
            alert( e.target.files[0].name)
        }

        return {
            checkedYes, 
            checkedNo, 
            clickYes, clickNo, 
            soliders,
            clickImg,
            getSolider,
            saveSoldier,
            ...toRefs ( soliderForm ),
            getSoliderFirstName,
            setImage, 
        }
    },
}
</script>


<style>
    .add-image {
        border-radius: 8px;
        border: 1px solid #DED9D2 ;
    }

    .show-chosen{
        border-radius: 20px;
        border: 1px solid #DED9D2;
        background-color: #DED9D2;
        padding: 5px;
        margin-top: 5px;
        margin-left: 10%;
        width: 80%;  
    }

    .see-solider-form{
         border-top: 1px solid gray;
    }
</style>