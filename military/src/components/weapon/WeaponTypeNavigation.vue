 <template>

    <nav class="pb-5"> <!---->
        <div class="navigation-box">

            <ul class="nav justify-content-center">
                <li class="nav-item">
                    <button href="#" @click="getAllWeapons" class="btn btn-light nav-link text-dark">{{allType}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeSkarpskyttergevær)" class="btn btn-light nav-link text-dark">{{typeSkarpskyttergevær}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeAutomatgevær)" class="btn btn-light nav-link text-dark">{{typeAutomatgevær}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typePanservernvåpen)" class="btn btn-light nav-link text-dark">{{typePanservernvåpen}}</button>
                </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeMaskingevær)" class="btn btn-light nav-link text-dark">{{typeMaskingevær}}</button>
               </li>
                <li class="nav-item">
                    <button href="#" @click="getWeaponByType(typeMaskinpistol)" class="btn btn-light nav-link text-dark">{{typeMaskinpistol}}</button>
               </li>
            </ul>
        </div>
    </nav>

    <!-- OUTPUT ALLE -->
    <section class="row" v-if="checkAll.clicked">
        <weapon-item 
            v-for="(weapon, i) in weapons"
            :key="i"
            :id="weapon.id"
            :name="weapon.name"
            :type="weapon.type"
            :image="weapon.image"
            :magazinSize="weapon.magazinSize"
        ></weapon-item>
    </section>

    <!-- OUTPUT BASERT PÅ SØK -->
    <section class="row" v-if="checkElev.clicked">
        <weapon-item 
            v-for="(weapon, i) in weaponOut[1]"
            :key="i"
            :id="weapon.id"
            :name="weapon.name"
            :type="weapon.type"
            :image="weapon.image"
            :magazinSize="weapon.magazinSize"
        ></weapon-item>
    </section>

</template>

<script>
import { reactive, ref } from 'vue'
import weaponService from "../../services/weapon/weaponService.js"
import WeaponItem from "./WeaponItem.vue"

export default {
    setup() {

        const weapons = weaponService.getAllWeapons();
        const allType = ref("Alle");

        const typeSkarpskyttergevær = ref("Skarpskyttergevær");
        const typeAutomatgevær = ref("Automatgevær");
        const typePanservernvåpen = ref("Panservernvåpen");
        const typeMaskingevær = ref("Maskingevær");
        const typeMaskinpistol = ref("Maskinpistol");
       
        
        /* KONTROLLERER OUPUT BASERT PÅ KNAPPENE */
        const checkElev = reactive({
            clicked: false
        })

         const checkAll = reactive({
            clicked: true
        })

        /* SKRIVER UT ALLE SOLDATER */
        const getAllWeapons = async () => {
            checkAll.clicked = true;
            checkElev.clicked = false;

            return weapons
        }
        
        /* SKRIVER UT SOLDAT BASERT PÅ VALGT GRAD*/
        let weaponOut = ref ([""])
        
        const getWeaponByType = async (type) => {
            //const Weapons = soldierService.getAllWeapons();
            weaponOut.value.splice(1);
            checkElev.clicked = true;
            checkAll.clicked = false;
           
            let weaponType = await weaponService.getWeaponByType(type);
            weaponOut.value.push ( weaponType )

            return weaponOut
        }


        return {
            getAllWeapons, getWeaponByType, weaponService,
            typeSkarpskyttergevær, typeAutomatgevær, typePanservernvåpen,typeMaskingevær, typeMaskinpistol,
            allType, weapons, weaponOut,
            checkElev, checkAll, 
        }
    },

    components: {
        WeaponItem
    }
    
}
</script>


