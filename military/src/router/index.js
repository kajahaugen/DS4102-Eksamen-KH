import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import SoliderView from '../views/SoliderView.vue'
import WeaponView from '../views/WeaponView.vue'
import VehicleView from '../views/VehicleView.vue'
import MissionView from '../views/MissionView.vue'

const routes = [ 
    {
        name: "Hjem",
        path: "/",
        component: Home
    },
    {
        name: "Soldat",
        path: "/solider",
        alias: ["/soldat", "/soldater"],
        component: SoliderView
    },
    {
        name: "Våpen",
        path: "/weapon",
        alias: ["/våpen", "/weapons"],
        component: WeaponView
    },
    {
        name: "Kjøretøy",
        path: "/vehicle",
        alias: ["/vehicles", "/kjøretøy", "/fly", "/båt"],
        component: VehicleView
    },
    {
        name: "Oppdrag",
        path: "/mission",
        alias: ["/oppdrag", "/missions",],
        component: MissionView
    },
];


const router = createRouter({

    history: createWebHistory(),
    routes
})


export default router