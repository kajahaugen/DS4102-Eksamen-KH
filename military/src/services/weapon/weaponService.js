import axios from "axios";
import { ref } from "vue";

const weaponService = (function(){

    const weapons = ref( [
        {id: 0, name: "", type: "", image: "", magazinSize: parseInt("") },
    ])

    const getAllWeapons = () => weapons;
    const weaponControllerUrl = "https://localhost:7295/Weapon";

    /* HENTER VÅPEN */
    ( async () => { 
        const requestWeapon = await axios.get(weaponControllerUrl);
        weapons.value = requestWeapon.data; 
    } ) ();     

    /* HENTER VÅPEN BASERT PÅ ID */
    const getWeaponById = async (id) => {
        const request = await axios.get(`${weaponControllerUrl}/${id}`); 
        return request.data;
    };

    /* HENTER VÅPEN BASERT PÅ NAVN */
    const getWeaponByName = async (name) => {
        const request = await axios.get(`${weaponControllerUrl}/GetByName/${name}`); 
        return request.data;
    };

    /* HENTER SOLDATER BASERT PÅ GRAD */
    const getWeaponByType = async (type) => {
        const request = await axios.get(`${weaponControllerUrl}/getByType/${type}`); 
        return request.data;
    };

    /* PUTTER ENDREDE SOLDATER INN I DATABSEN */
    const putWeapon = async (editedWeapon) => {
        const request = await axios.put(weaponControllerUrl, editedWeapon)
        console.log(request)
    };

    /* LAGER NYE SOLDATER */
    const postNewWeapon = async ( newWeapon ) => {
        const request = await axios.post( weaponControllerUrl, newWeapon );
        weapons.value.push( newWeapon )
        console.log(request)
    }

    /* SLETTER SOLDAT */
    const deleteWeapon = async ( deleteWeapon ) => {
        await axios.delete( `${weaponControllerUrl}/${deleteWeapon} `);
    }

    /* BILDEOPPLASTNING */

    const imageUploadControllerUrl = "https://localhost:7295/image/postWeaponImage";


    const postImageWeapon = async ( newWeapon, image ) => {
        axios.post( weaponControllerUrl, newWeapon );
        weapons.value.push( newWeapon )
        axios({
            method: "POST",
            url: imageUploadControllerUrl,
            data: image,
            config: { header: {"Content-Type": "multipart/form-data"} }
        });
    
        
    }

    return {
        getAllWeapons, getWeaponById, postNewWeapon, putWeapon, 
        getWeaponByName, postImageWeapon, deleteWeapon, getWeaponByType
    }
    

}() )

export default weaponService;