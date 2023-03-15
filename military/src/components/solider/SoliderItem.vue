<template>
    <article class="col-xl-3 col-lg-4 col-md-6 col-sm-12 mb-5">

        <div class="card bg-primary" style="width: 18rem;">
            <img class="card-img-top" style="height: 337px; object-fit: cover;" :src="getSoliderImg()" :alt="`profilbilde av: ${firstName}`">
            <div class="card-body">
                <h3 class="card-title text-center">{{firstName}} {{lastName}}</h3>
                <h5 class="card-text text-center">{{grade}}</h5>
            </div>

            <ul class="list-group list-group-flush">
                <li class="list-group-item bg-primary">
                    <p>Født: </p>
                    <h5>{{birthdate}}</h5>
                </li>
                <li class="list-group-item bg-primary">
                    <p>Ute på oppdrag: </p>
                    <div v-if="outOnMission">
                        <h5> Ja </h5>
                        <p class="pt-4"> Soldatens oppdrag:</p>
                        <h5 ><i>{{missionName}}</i></h5>
                    </div>
                    <div v-else>  
                        <h5 >Nei</h5>
                    </div>
                </li>
            </ul>  
        </div>

    </article>
</template>


<script>
export default {
    props: {
        id: Number,
        firstName: String, 
        lastName: String, 
        image: String, 
        birthdate: String, 
        grade: String, 
        ranking: String, 
        outOnMission: Boolean, 
        missionName: String,
    },

    setup(props){

        const getSoliderImg = () => {
            let image;
            try { 
                image = `https://localhost:7295/images/Soliders/${props.image }`
            } catch {
                image = "no image";
            }
            return image;
        }

        return { getSoliderImg }
    },
}
</script>


<style>
    .btn-change{
        margin-left: 25%;
        padding-top: 8px;
        padding-bottom: 8px;
        border-radius: 30px;
    }
</style>