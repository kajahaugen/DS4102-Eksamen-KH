<template>
    <article class="col-xl-3 col-lg-4 col-md-6 col-sm-12 mb-5">

        <div class="card bg-primary" style="width: 18rem;">
            <img class="card-img-top" style="height: 120px; object-fit: cover;" :src="getWeaponImg()" :alt="`profilbilde av: ${name}`">
            <div class="card-body">
                <h3 class="card-title text-center">{{name}}</h3>
                <h5 class="card-text text-center">{{type}}</h5>
            </div>

            <ul class="list-group list-group-flush">
                <li class="list-group-item bg-primary">
                    <p class="text-center"> Magasinstørrelse på våpen: </p>
                    <h5 class="text-center">{{magazinSize}}</h5>
                </li>
            </ul>  
        </div>
 
    </article>
</template>

<script>


export default {
    props: {
        id: Number,
        name: String, 
        type: String, 
        image: String, 
        magazinSize: Number, 
    },

    setup(props){
        //let outputInputInformation = ref([])
        //let input = ref("")

        const getWeaponImg = () => {
            let image;
            try{ 
                image = `https://localhost:7295/images/Weapons/${props.image }`
            }catch{
                image = "no image";
            }
            return image;
        }

        return { getWeaponImg }
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