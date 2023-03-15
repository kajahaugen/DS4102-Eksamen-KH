<template>
    <section class="row">

        <form class="col-xl-5 col-lg-6 col-md-12 p-4 change-weapon-form bg-primary">
            <div class="form-group row">
                <h4 class="text-center mb-4">Hvilket våpen vil du endre? </h4>
                <div class="col-6">
                    <label for="id">Id</label>
                    <input v-model="inputId" type="text" class="form-control" placeholder="Våpens ID">
                    <input @click="getWeapon" class="show-chosen" type="button" value="Se Våpen">
                </div>
                <div class="col-6">
                    <label for="navn">Våpen navn</label>
                    <input v-model="inputName" type="text" class="form-control" placeholder="HK416">
                    <input @click="getWeaponByName" class="show-chosen" type="button" value="Se Våpen">
                </div>

                <div class="form-group mt-4 pt-4 see-solider-form">
                    <h4 class="text-center mb-4">Våpen: </h4>
                    <div class="bg-white add-image p-3 mb-4">
                        <h2>Last opp bilde</h2>

                        <div class="row">
                            <div class="col-8">
                                <input @change="setImage" class="form-control" type="file"> <!-- @change="setImage" (e) innholder informasjon og data-->
                            </div>
                            <div class="col-4">
                                <img v-if="clickImg.clicked" class="card-img-top" style="margin-top: -40px; height: 130px; width: 130px; object-fit: cover;" :src="`https://localhost:7295/images/Weapons/${image}`" :alt="`bilde av: ${inputName}`">
                            </div>
                        </div>
                    </div>  
                </div>
            </div>
             <div class="form-group mt-3">
                <label for="navn">Våpen navn</label>
                <input v-model="inputName" type="text" class="form-control" placeholder="HK416">
            </div>
            <div class="form-group mt-3">
                <label for="grade">Type våpen</label>
                <select v-model="selected" class="form-control">
                    <option>Skarpskyttergevær</option>
                    <option>Automatgevær</option>
                    <option>Panservernvåpen</option>
                    <option>Maskingevær</option>
                    <option>Maskinpistol</option>
                </select>
            </div>
            <div class="form-group  mt-1">
                <label for="magasinSize">Magasin størrelse</label>
                <input v-model="inputMagazinSize" type="text" class="form-control" placeholder="F.eks: Kadett">
            </div>
            <div class="form-group add-Weapon mt-4">
              <button @click="saveSoldier" type="button" class="btn btn-add-Weapon btn-secondary"> Lagre endringer </button>
            </div>
        </form>

    </section>
</template>

<script>
import WeaponService from "../../services/weapon/weaponService.js"
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
    const WeaponForm = reactive ({
        inputId: "",
        inputName: "",
        selected: "",
        image: "", 
        inputMagazinSize: "", 
    });
   
    // SKRIVER UT VÅPEN BASERT BASERT PÅ INPUT ID
    const weapons = WeaponService.getAllWeapons();

    const getWeapon = async () => { 
        clickImg.clicked = true
        const weapon = await WeaponService.getWeaponById(WeaponForm.inputId);
        
        WeaponForm.inputId = weapon.id;
        WeaponForm.inputName = weapon.name;  
        WeaponForm.selected = weapon.type;
        WeaponForm.image = weapon.image;
        WeaponForm.inputMagazinSize = weapon.magazinSize;
    }

     // SKRIVER UT VÅPEN BASERT BASERT PÅ INPUT ID
     const getWeaponByName = async () => { 
        const WeaponName = await WeaponService.getWeaponByName(WeaponForm.inputName);
        
        WeaponForm.inputId = WeaponName[0].id;
        WeaponForm.inputName = WeaponName[0].name;  
        WeaponForm.selected = WeaponName[0].type;
        WeaponForm.image = WeaponName[0].image;
        WeaponForm.inputMagazinSize = WeaponName[0].magazinSize;
    }

    // LAGRER ENDRET VÅPEN ID
    const saveSoldier = async () => {
        let weapon = await WeaponService.getWeaponById(WeaponForm.inputId);
        
        weapon.id = WeaponForm.inputId,
        weapon.name = WeaponForm.inputName,
        weapon.type = WeaponForm.selected, 
        weapon.image = WeaponForm.image
        weapon.magazinSize = WeaponForm.inputMagazinSize,

        alert("Ditt våpen er nå blitt endret")
        WeaponService.putWeapon( weapon )
        window.location.reload();
    }

    //FOR BILDE
    const image = new FormData();

    const setImage = (e) => {
        image.append("file", e.target.files[0]); 
        WeaponForm.image = e.target.files[0].name;
        alert( e.target.files[0].name)
    }
       
        return {
            checkedYes, 
            checkedNo, 
            clickYes, clickNo, 
            weapons,
            clickImg,
            getWeapon,
            saveSoldier,
            ...toRefs ( WeaponForm ),
            getWeaponByName,
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
    .change-weapon-form{
        margin: auto;
        width: 70%;
        border: 1px solid #DED9D2;
        border-radius: 6px;
    }
</style>