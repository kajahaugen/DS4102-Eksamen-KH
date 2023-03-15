import axios from "axios";
import { ref } from "vue";

const soldierService = (function(){


    /** LAGER KLAR HVORDAN ET OBJEKT SER UT **/
    const soliders = ref( [
        {id: 0, firstName: "", lastName: "", image: "", birthdate: "", grade: "", ranking: "", outOnMission: "", missionName: "" },
    ]);

    const getAllSoliders = () => soliders;

    const soliderControllerUrl = "https://localhost:7295/solider";

    /* HENTER SOLDATER */
    ( async () => { 
        const requestSolider = await axios.get(soliderControllerUrl);
        soliders.value = requestSolider.data; 
    } ) ();     

    /* HENTER SOLDATER BASERT PÅ ID */
    const getSoliderById = async (id) => {
        const request = await axios.get(`${soliderControllerUrl}/${id}`); 
        return request.data;
    };

    /* HENTER SOLDATER BASERT PÅ NAVN */
    const getSoliderByFirstName = async (firstName) => {
        const request = await axios.get(`${soliderControllerUrl}/getByFirstName/${firstName}`); 
        return request.data;
    };

    /* HENTER SOLDATER BASERT PÅ GRAD */
    const getSoliderByGrade = async (grade) => {
        const request = await axios.get(`${soliderControllerUrl}/getByGrade/${grade}`); 
        return request.data;
    };

    /* PUTTER ENDREDE SOLDATER INN I DATABSEN */
    const putSolider = async (editedSolider) => {
        const request = await axios.put(soliderControllerUrl, editedSolider)
        console.log(request)
    };

    /* LAGER NYE SOLDATER */
    const postNewSolider = async ( newSolider ) => {
        const request = await axios.post( soliderControllerUrl, newSolider );
        soliders.value.push( newSolider )
        console.log(request)
    }

    /* SLETTER SOLDAT */
    const deleteSolider = async ( deleteSolider ) => {
        await axios.delete( `${soliderControllerUrl}/${deleteSolider} `);
    }

    /* BILDEOPPLASTNING */

    const imageUploadControllerUrl = "https://localhost:7295/image/postSoliderImage";

   

    const postImageSolider = async ( newSolider, image ) => {
        axios.post( soliderControllerUrl, newSolider );
        soliders.value.push( newSolider )
        axios({
            method: "POST",
            url: imageUploadControllerUrl,
            data: image,
            config: { header: {"Content-Type": "multipart/form-data"} }
        });
    
        
    }

    /*( async () => { 
        const requestSoliderImage = await axios.get(soliderControllerUrl);
        soliders.value = requestSoliderImage.data; 
    } ) ();*/


    return {
        getAllSoliders, getSoliderById, postNewSolider, putSolider, 
        getSoliderByFirstName, postImageSolider, deleteSolider, getSoliderByGrade
    }
    

}() )

export default soldierService;