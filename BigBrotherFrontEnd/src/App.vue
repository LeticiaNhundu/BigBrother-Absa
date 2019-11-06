<template>
  <div id="app">
      
<template>
  <div class="page-container">
    <md-app>
      <md-app-toolbar class="md-primary" md-elevation="0">
        <md-button class="md-icon-button" @click="toggleMenu" v-if="!menuVisible">
          <md-icon>menu</md-icon>
        </md-button>
        <span class="md-title">Big Brother</span>
      </md-app-toolbar>

      <md-app-drawer class="drawer"  :md-active.sync="menuVisible" md-persistent="mini">
        <md-toolbar class="md-transparent" md-elevation="0">
          <span>Navigation</span>

          <div class="md-toolbar-section-end">
            <md-button class="md-icon-button md-dense" @click="toggleMenu">
              <md-icon>keyboard_arrow_left</md-icon>
            </md-button>
          </div>
        </md-toolbar>

        <md-list>
          <md-list-item router-link to="/home">
            <md-icon>home</md-icon>
            <span class="md-list-item-text">Home</span>
          </md-list-item>

          <md-list-item router-link to="/trainer">
            <md-icon>person_add</md-icon>
            <span class="md-list-item-text">Model Trainer</span>
          </md-list-item>

          <md-list-item router-link to="/team">
            <md-icon>people_alt</md-icon>
            <span class="md-list-item-text">Teams</span>
          </md-list-item>
          
        </md-list>
      </md-app-drawer>

      <md-app-content>
        <router-view/>
      </md-app-content>
    </md-app>
  </div>
</template>


  </div>
</template>

<script>

export default {
  name: 'App',
  components: {
    },
    data: () => ({
      menuVisible: false
    }),
    methods: {
      toggleMenu () {
        this.menuVisible = !this.menuVisible
      }
    }
}
</script>

<style lang="scss" scoped>
#app {
  text-align: center;
}


.md-app {
    min-height: 100vh;
    border: 1px solid rgba(#000, .12);
  }
.drawer{
  height: 100%;
}

</style>
