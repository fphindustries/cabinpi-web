<template>
  <div>
    <div class="column flexv flexch" id="column_65" style="">
      <h3 id="htmlTag_66" class="htmlTag text-blue-3">Master Systems Display</h3>
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
        <div id="text_75" class="text" style="width: 65px;">00</div>
        <div class="button" id="button_76" data-label="Type B"></div>
      </div>
      <div class="complexButton bg-blue-1" id="complexButton_80">
        <div class="button" id="button_78" data-label="Type BR"></div>
        <div id="text_79" class="text" style="width: 65px;">00</div>
      </div>
      <div class="complexButton bg-green-2" id="complexButton_84">
        <div class="block" id="block_81"></div>
        <div id="text_82" class="text" style="width: 65px;">00</div>
        <div class="button" id="button_83" data-label="Type C"></div>
      </div>
      <div class="complexButton bg-blue-1" id="complexButton_88">
        <div class="button" id="button_85" data-label="Type CR"></div>
        <div id="text_86" class="text" style="width: 65px;">00</div>
        <div class="block" id="block_87"></div>
      </div>
      <div class="complexButton bg-green-4" id="complexButton_92">
        <div id="text_89" class="text" style="width: 65px;">00</div>
        <div class="button" id="button_90" data-label="Type D"></div>
        <div class="bar" id="bar_91"></div>
      </div>
      <div class="complexButton bg-blue-3" id="complexButton_96">
        <div class="block" id="block_93"></div>
        <div class="button" id="button_94" data-label="Type DR"></div>
        <div id="text_95" class="text" style="width: 65px;">00</div>
      </div>
      <div class="complexButton bg-green-4" id="complexButton_100">
        <div class="cap left" id="cap_97"></div>
        <div class="button" id="button_98" data-label="Type E"></div>
        <div id="text_99" class="text" style="width: 65px;">00</div>
      </div>
      <div class="complexButton bg-blue-3" id="complexButton_104">
        <div id="text_101" class="text" style="width: 65px;">00</div>
        <div class="button" id="button_102" data-label="Type ER"></div>
        <div class="cap right" id="cap_103"></div>
      </div>
      <div class="complexButton bg-green-3" id="complexButton_110">
        <div class="cap left" id="cap_105"></div>
        <div class="button" id="button_106" data-label="Type F"></div>
        <div class="block" id="block_107"></div>
        <div id="text_108" class="text" style="width: 65px;">00</div>
        <div class="block" id="block_109"></div>
      </div>
      <div class="complexButton bg-blue-3" id="complexButton_116">
        <div class="block" id="block_111"></div>
        <div id="text_112" class="text" style="width: 65px;">00</div>
        <div class="block" id="block_113"></div>
        <div class="button" id="button_114" data-label="Type FR"></div>
        <div class="cap right" id="cap_115"></div>
      </div>
      <div class="complexButton bg-blue-1" id="complexButton_121">
        <div class="cap left" id="cap_117"></div>
        <div class="block" id="block_118"></div>
        <div id="text_119" class="text" style="width: 65px;">00</div>
        <div class="button right" id="button_120" data-label="Type G"></div>
      </div>
      <div class="complexButton bg-blue-4" id="complexButton_126">
        <div class="button left" id="button_122" data-label="Type GR"></div>
        <div id="text_123" class="text" style="width: 65px;">00</div>
        <div class="block" id="block_124"></div>
        <div class="cap right" id="cap_125"></div>
      </div>
    </div>
                              <div id="title_3" class="title">LCARS SDK Visual Guide</div>
                              <div class="bar flexch bg-green-4" id="bar_4"></div>

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
import restClient from '../services/restClient';

export default {
  components: {
  },
  data() {
    return {
      sht31: {},
      bmp280: {},
      ds18b20: {},
      ina219: {},
    };
  },
  methods: {
    loadSensors() {
      restClient.getSht31().then((data) => {
        this.sht31 = data;
      });
      restClient.getBmp280().then((data) => {
        this.bmp280 = data;
      });
      restClient.getDs18b20().then((data) => {
        this.ds18b20 = data;
      });
      restClient.getIna219().then((data) => {
        this.ina219 = data;
      });
    },
  },
  created() {
    this.loadSensors();
  },
};
</script>
