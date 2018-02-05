<template>
  <div>
    <div class="column flexv flexch" id="column_65" style="width:350px">
      <h3 id="htmlTag_66" class="htmlTag text-blue-3">Environmental Systems</h3>
      <div class="complexButton bg-blue-2" id="complexButton_70">
        <div class="cap left" id="cap_67"></div><div id="text_68" class="text" >{{ sht31.fahrenheit | formatNumber }}</div>
        <div class="button" id="button_69" data-label="Interior"></div>
      </div>
      <div class="complexButton bg-green-4" id="complexButton_74">
        <div class="button" id="button_71" data-label="Exterior"></div>
        <div id="text_72" class="text">{{ ds18b20.fahrenheit | formatNumber}}</div>
        <div class="cap right" id="cap_73"></div>
      </div>
      <div class="complexButton bg-green-1" id="complexButton_77">
        <div id="text_75" class="text">{{ sht31.humidity | formatNumber}}</div>
        <div class="button" id="button_76" data-label="Humidity"></div>
      </div>
      <div class="complexButton bg-blue-1" id="complexButton_80">
        <div class="button" id="button_78" data-label="Pressure"></div>
        <div id="text_79" class="text">{{ bmp280.inHg | formatNumber}}</div>
      </div>
    </div>
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
        ds18b20: {}
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
      }
    },
    created () {
      this.loadSensors();
    }
  };
</script>
