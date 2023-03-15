<template>
<h1 class="text-center">SKJEMA FOR Å SLETTE SOLDAT</h1>
    <section class="row">

        <form class="col-xl-5 col-lg-6 col-md-12 p-4 add-solider-form bg-primary">
            <div class="form-group row">
                <h2 class="text-center">Hvilken soldat vil du slette? </h2>
                <div class="col-6">
                    <label for="firstname">Id</label>
                    <input v-model="inputId" type="text" class="form-control" placeholder="Soldats ID">
                    <input @click="getSolider" class="show-chosen" type="button" value="Se Soldat">
                </div>
                <div class="col-6">
                    <label for="firstname">Fornavn</label>
                    <input v-model="inputFirstName" type="text" class="form-control" placeholder="Kari">
                    <input @click="getSoliderFirstName" class="show-chosen" type="button" value="Se Soldat">
                </div>

                <div class="form-group mt-4 pt-4 see-solider-form">
                    <h4 class="text-center mb-4">Soldat: </h4>
                    <div class="bg-white add-image p-3 mb-4" style="margin: auto; width: 220px;">
                        <img v-if="clickImg.clicked" class="card-img-top" style="margin: auto; width: 35%; border-radius: 10px; height: 180px; width: 180px; object-fit: cover;" :src="`https://localhost:7295/images/soliders/${image}`" :alt="`bilde av: ${inputFirstName}`">
                    </div>  
                </div>
                <div class="bg-white output-field col-5 col-lg-3">
                    <label for="firstname">Fornavn:</label>
                    <h4>{{inputFirstName}}</h4>
                </div>
                <div class="bg-white output-field col-5 col-lg-4">
                    <label for="lastname">Etternavn:</label>
                    <h4>{{inputLastName}}</h4>
                </div>
                <div class="bg-white output-field col-11 col-lg-4">
                    <label for="lastname">Fødselsdato:</label>
                    <h4>{{inputBirthdate}}</h4>
                </div>
            </div>

             <div class="bg-white output-field mt-3">
                <label for="grad">Rangeringsgrad:</label>
                <h4>{{selected}}</h4>
                <label for="ranking">Rangering:</label>
                <h4>{{inputRanking}}</h4>
            </div>
            
          
            <div class="form-group add-solider mt-4">
              <button @click="deleteSolider" type="button" class="btn btn-add-solider btn-secondary"> Slett denne soldaten </button>
            </div>
            
        </form>

    </section>
</template>

<script>
import soliderService from "../../services/solider/soliderService.js"

import {reactive, toRefs } from '@vue/reactivity'
/*import soldierService from '../../services/solider/soliderService.js'*/

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
    const deleteSolider = async () => {
        let solider = await soliderService.getSoliderById(soliderForm.inputId);
          
        solider.id = soliderForm.inputId,
        solider.firstName = soliderForm.inputFirstName,
        solider.lastName = soliderForm.inputLastName, 
        solider.image = soliderForm.image
        solider.birthdate = soliderForm.inputBirthdate,
        solider.grade = soliderForm.selected,
        solider.ranking = soliderForm.inputRanking,

        alert("Din soldat er nå slettet")
        soliderService.deleteSolider( soliderForm.inputId )
        window.location.reload();
    }

    //FOR BILDE
    
        const image = new FormData();

       
        const setImage = (e) => {
            image.append("file", e.target.files[0]); //e.target betyr tingen som er trykket på
            soliderForm.image = e.target.files[0].name;
            alert( e.target.files[0].name)
        } //klargjør bildeobjektet
       


        return {
            checkedYes, 
            checkedNo, 
            clickYes, clickNo, 
            soliders,
            clickImg,
            getSolider,
            deleteSolider,
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

    .output-field {
        border: 1px solid #DED9D2;
        margin-left: 15px;
        padding: 10px;
        border-radius: 10px;
        margin-top: 5px;
    }
</style>