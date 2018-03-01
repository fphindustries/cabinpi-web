<template>
  <div>
    <h1>YouSuck</h1>
  <md-app-drawer md-permanent="full">
    <md-toolbar class="md-transparent" md-elevation="0">
      Navigation
    </md-toolbar>
    <md-list>
      <md-list-item>
        <router-link class="" to="/" exact=""  data-label="Home">
          <md-icon>move_to_inbox</md-icon>
          <span class="md-list-item-text">Home</span>
        </router-link>
      </md-list-item>

      <md-list-item>
        <router-link class="" to="/environment" exact="" data-label="Environment">
          <md-icon>send</md-icon>
          <span class="md-list-item-text">Sent Mail</span>
        </router-link>
      </md-list-item>

      <md-list-item>
        <router-link class="" to="/power" exact="" data-label="Power">
          <md-icon>delete</md-icon>
          <span class="md-list-item-text">Trash</span>
        </router-link>
      </md-list-item>

      <md-list-item>
        <router-link class="" to="/forecast" exact="" data-label="Forecast">
          <md-icon>error</md-icon>
          <span class="md-list-item-text">Spam</span>
        </router-link>
      </md-list-item>
    </md-list>
  </md-app-drawer>
  </div>
</template>

<script>
export default {
};
</script>
