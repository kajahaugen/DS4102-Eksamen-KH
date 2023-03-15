<template>
    <section class="row">

        <form class="col-xl-5 col-lg-6 col-md-12 p-4 add-weapon-form bg-primary">
            <div class="form-group row">
                <h4 class="text-center mb-4">Hvilket våpen vil du slette? </h4>
                <div class="col-6">
                    <label for="id">Id</label>
                    <input v-model="inputId" type="text" class="form-control" placeholder="Våpens ID">
                    <input @click="getWeapon" class="show-chosen" type="button" value="Se Våpen">
                </div>
                <div class="col-6">
                    <label for="name">Navn på våpen</label>
                    <input v-model="inputName" type="text" class="form-control" placeholder="Barrett M82">
                    <input @click="getWeaponByName" class="show-chosen" type="button" value="Se Våpen">
                </div>

                <div class="form-group mt-4 pt-4 see-solider-form">
                    <h4 class="text-center mb-4">Våpen: </h4>
                    <div class="bg-white add-image p-3 mb-4" style="margin: auto; width: 300px;">
                        <img v-if="clickImg.clicked" class="card-img-top" style="margin: auto; width: 35%; border-radius: 10px; height: 100px; width: 250px; object-fit: cover;" :src="`https://localhost:7295/images/Weapons/${image}`" :alt="`bilde av: ${inputName}`">
                    </div>  
                </div>
                <div class="bg-white output-field col-11 col-lg-4">
                    <label for="name">Navn:</label>
                    <h4>{{inputName}}</h4>
                </div>
                <div class="bg-white output-field col-11 col-lg-4">
                    <label for="type">Type:</label>
                    <h4>{{inputType}}</h4>
                </div>
                <div class="bg-white output-field col-11 col-lg-3">
                    <label for="magazine">Magasinstørrelse:</label>
                    <h4>{{inputMagazinSize}}</h4>
                </div>
            </div>
          
            <div class="form-group add-weapon mt-4">
              <button @click="deleteWeapon" type="button" class="btn btn-add-weapon btn-secondary"> Slett dette våpenet </button>
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
        inputType: "",
        image: "", 
        inputMagazinSize: "",
    });

    const Weapons = WeaponService.getAllWeapons();

    // SKRIVER UT VÅPEN BASERT BASERT PÅ INPUT ID
     const getWeapon = async () => { 
        clickImg.clicked = true
        const Weapon = await WeaponService.getWeaponById(WeaponForm.inputId);
        
        console.log(Weapon)
        WeaponForm.inputId = Weapon.id;
        WeaponForm.inputName = Weapon.name;  
        WeaponForm.inputType = Weapon.type;
        WeaponForm.image = Weapon.image;
        WeaponForm.inputMagazinSize = Weapon.magazinSize;
    }

     // SKRIVER UT VÅPEN BASERT BASERT PÅ INPUT NAVN
     const getWeaponByName = async () => { 
        clickImg.clicked = true
        const WeaponName = await WeaponService.getWeaponByName(WeaponForm.inputName);
        
        WeaponForm.inputId = WeaponName[0].id;
        WeaponForm.inputName = WeaponName[0].name;  
        WeaponForm.inputType = WeaponName[0].type;
        WeaponForm.image = WeaponName[0].image;
        WeaponForm.inputMagazinSize = WeaponName[0].magazinSize;
    }


    // LAGRER ENDRET VÅPEN ID
    const deleteWeapon = async () => {
        let Weapon = await WeaponService.getWeaponById(WeaponForm.inputId);
          
        Weapon.id = WeaponForm.inputId,
        Weapon.name = WeaponForm.inputName,
        Weapon.type = WeaponForm.inputType, 
        Weapon.image = WeaponForm.image
        Weapon.magazinSize = WeaponForm.inputMagazinSize,

        alert("Ditt våpen er nå slettet")
        WeaponService.deleteWeapon( WeaponForm.inputId )
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
            Weapons,
            clickImg,
            getWeapon,
            deleteWeapon,
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
    .output-field {
        border: 1px solid #DED9D2;
        margin-left: 15px;
        padding: 10px;
        border-radius: 10px;
        margin-top: 5px;
    }
</style>