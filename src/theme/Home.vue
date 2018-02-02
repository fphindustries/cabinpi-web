<template>
  <div>
    <p>Interior: {{ sht31.fahrenheit}}</p>
    <p>Humidity: {{ sht31.humidity}}</p>
    <p>Exterior: {{ ds18b20.fahrenheit}}</p>
    <p>Pressure: {{ bmp280.inHg}}</p>
    <p>Current: {{ ina219.current}}</p>
    <p>Power: {{ ina219.power}}</p>
    <p>Voltage: {{ ina219.voltage}}</p>
  </div>
</template>

<script>
  import appService from '../app.service';

  export default {
    components: {
    },
    data () {
      return {
        sht31: {},
        bmp280: {},
        ds18b20: {},
        ina219: {}
      };
    },
    methods: {
      loadSensors () {
        appService.getSht31().then(data => {
          this.sht31 = data;
        });
        appService.getBmp280().then(data => {
          this.bmp280 = data;
        });
        appService.getDs18b20().then(data => {
          this.ds18b20 = data;
        });
        appService.getIna219().then(data => {
          this.ina219 = data;
        });
      }
    },
    created () {
      this.loadSensors();
    }
  };
</script>
