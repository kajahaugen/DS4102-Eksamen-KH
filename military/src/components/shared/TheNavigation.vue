<template>

    <nav class="pb-5"> <!---->
        <div class="navigation-box">
              <div> 
                <ul class="nav justify-content-center">
                    <li class="nav-item">
                    <router-link class="justify-content-center p-3" to="/"><img src="../../assets/logo-hæren.png" ></router-link> <!-- Dette skal bli link med logo-->
                    </li>
                </ul>
            </div>
            <ul class="nav justify-content-center">
                <li class="nav-item">
                    <router-link class="nav-link active" aria-current="page" href="#" to="/">Hjem</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link active" aria-current="page" href="#" to="/solider">Soldater</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link active" aria-current="page" href="#" to="/mission">Oppdrag</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link active" aria-current="page" href="#" to="/vehicle">Kjøretøy</router-link> 
               </li>
                <li class="nav-item">
                    <router-link class="nav-link active" aria-current="page" href="#" to="/weapon">Våpen</router-link> 
               </li>
            </ul>
        </div>
    </nav>

</template>

<style lang="scss">
    .nav-link.active {
        color: black;
        font-size: 20px;
    }

    .navigation-box {
        border-bottom: 1px solid black;
    }
    @import "node_modules/bootstrap/scss/bootstrap";
        
</style>