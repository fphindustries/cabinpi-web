<template>
  <div>
    <p>Interior: {{ sensors.interiorTemp}}</p>
    <p>Exterior: {{ sensors.exteriorTemp}}</p>
  </div>
</template>

<script>
  import appService from '../app.service';

  export default {
    components: {
    },
    data () {
      return {
        sensors: {}
      };
    },
    methods: {
      loadSensors () {
        appService.getSensors().then(data => {
          this.sensors = data;
        });
      }
    },
    created () {
      this.loadSensors();
    }
  };
</script>
