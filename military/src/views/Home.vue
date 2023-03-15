<template>
    <div class="container">

        <!--BANNER -->
        <section class="row">
            <div class="col-12 bg-image">
                <img src="../assets/norway-bg.jpg" class="" style="height: 250px; object-fit: cover; width: 100%">
            </div>
            <div class="col-12" style="margin-top: -130px;" > 
                <h3 class="text-center p-2" style="background-color: rgba(255,255,255, 0.5);"> Hjemmeside militæret  </h3> 
            </div>
        </section>
        
        <!--KNAPP NAVIGASON AV SIDENE -->
        <section>
            <nav> 
            <div class="mt-4">
                <ul class="row nav d-flex justify-content-around">
                    <li class="nav-item col-md-2 col-4	">
                        <button class="p-4 home-nav-button bg-primary">
                            <router-link class="nav-link active" aria-current="page" href="#" to="/solider">Soldater</router-link>
                        </button>
                    </li>
                    <li class="nav-item col-md-2 col-4">
                        <button class="p-4 home-nav-button bg-primary">
                            <router-link class="nav-link active" aria-current="page" href="#" to="/mission">Oppdrag</router-link>
                        </button>
                    </li>
                    <li class="nav-item col-md-2 col-5">
                        <button class="p-4 home-nav-button bg-primary">
                            <router-link class="nav-link active" aria-current="page" href="#" to="/vehicle">Kjøretøy</router-link> 
                        </button>
                    </li>
                    <li class="nav-item col-md-2 col-4">
                        <button class="p-4 home-nav-button bg-primary">
                            <router-link class="nav-link active" aria-current="page" href="#" to="/weapon">Våpen</router-link> 
                        </button>
                    </li>
                </ul>
            </div>
        </nav>
    </section>

    </div>
</template>


<style>
    .home-nav-button {
        border-radius: 8px;
        border: 1px solid #DED9D2 ;
        margin-bottom: 30px;
    }
</style>