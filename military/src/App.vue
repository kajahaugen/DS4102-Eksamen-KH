<template>
  <div class="container">
  <!-- HEADER / NAVIGATION -->
    <the-navigation></the-navigation>
    
    <div>
      <!-- PAGES -->
      <router-view></router-view>
    </div>
    

  <!-- FOOTER -->
 </div>

</template>

<script>
import 'bootstrap/dist/css/bootstrap.min.css' 
import 'bootstrap-icons/font/bootstrap-icons.css' 

import TheNavigation from "./components/shared/TheNavigation.vue"


export default {
  name: 'App',
  components: {
    TheNavigation,
  }
}
</script>


<style lang="scss">
    $theme-colors: (
      "primary": #EFF0EE,
      "secondary": #DED9D2,
      "danger": #ff5d55,
      //"success":    $success,
      //"info":       $info,
      //"warning":    $warning,
      //"light":      $light,
      //"dark":       $dark
       
    );

    @import "node_modules/bootstrap/scss/bootstrap";
</style>
