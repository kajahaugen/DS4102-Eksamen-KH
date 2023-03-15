<template>
    <div>
        <section class="row">

            <form class="col-xl-5 col-lg-6 col-md-12 p-4 add-weapon-form bg-primary">

                <h4 class="text-center mb-4">Legg til våpen </h4>

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
                        <label for="name">Navn på våpen</label>
                        <input v-model="inputName" type="text" class="form-control" placeholder="Barett M82">
                    </div>
                    <div class="col-6">
                        <label for="magazinsize">Størrelse på magasinet</label>
                        <input v-model="inputMagazinSize" type="number" class="form-control" placeholder="82">
                    </div>
                </div>
                
                <div class="form-group mt-3">
                    <label for="grade">Type våpen</label>
                    <select v-model="selected" class="form-control" >
                        <option>Skarpskyttergevær</option>
                        <option>Automatgevær</option>
                        <option>Panservernvåpen</option>
                        <option>Maskingevær</option>
                        <option>Maskinpistol</option>
                    </select>
                </div>

                <div class="form-group add-weapon mt-4">
                    <button @click="AddWeapon" type="button" class="btn btn-add-weapon btn-secondary"> Legg til Våpen</button>
                </div>                
            </form>
        </section>
    </div>
</template>

<script>
import WeaponService from "../../services/weapon/weaponService.js"
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
    const weapons = WeaponService.getAllWeapons();

    const inputName = ref(inputName);
    const selected = ref(selected);
    const inputMagazinSize = ref(inputMagazinSize);
    const inputImage = ref(inputImage);
   
   
    /* VÅPEN OBJEKT GJØRES KLART */
    const newWeapon = ref (
        { name: inputName, type: selected, magazinSize: inputMagazinSize,  image: inputImage  },
    );

    /* BILDE */
    const image = new FormData();
        
    const setImage = (e) => {
        image.append("file", e.target.files[0]);
        newWeapon.value.image = e.target.files[0].name;
    } 
       

    /* VÅPEN LEGGES TIL OG PUBLISERES */
    const AddWeapon = () => { 
        WeaponService.postImageWeapon( newWeapon.value, image )
        alert("Ditt Våpen er nå lagt til")
    }
       
        return {
            checkedYes, 
            checkedNo, 
            clickYes, clickNo, 
            AddWeapon,
            weapons,
            newWeapon,
            inputName,
            inputMagazinSize,
            inputImage,
            selected,
            setImage,  
        }
    }, 
}
</script>

<style>
    .add-weapon-form{
        margin: auto;
        width: 70%;
        border: 1px solid #DED9D2;
        border-radius: 6px;
    }

    .add-weapon {
        margin: auto;
        width: 30%;
    }

    .btn-add-weapon {
        border-radius: 20px;
    }
</style>