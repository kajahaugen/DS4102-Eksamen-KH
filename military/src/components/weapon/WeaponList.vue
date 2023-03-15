<template>
    <section class="row">
        
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
</template>

<script>
import WeaponItem from "./WeaponItem.vue"
import weaponService from '../../services/weapon/weaponService';


export default {
    setup() {
        const weapons = weaponService.getAllWeapons();
        
        return {
            weapons
        }
    },

    components: {
        WeaponItem,
          
    }

}
</script>