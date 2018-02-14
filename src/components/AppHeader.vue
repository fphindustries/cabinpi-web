<template>
  <div class="column flexv primary-menu" style="width:250px; margin-top:148px;" data-section="visual-guide">
      <div class="complexButton">
        <router-link class="button bg-green-1" to="/" exact=""  data-label="Master Systems Display">
        </router-link>
      </div>
      <div class="complexButton">
        <router-link class="button bg-green-3" to="/environment" exact="" data-label="Environmental">
        </router-link>
      </div>
      <div class="complexButton">
        <router-link class="button bg-blue-3" to="/power" exact="" data-label="Power">
        </router-link>
      </div>
      <div class="complexButton">
        <router-link class="button bg-blue-1" to="/forecast" exact="" data-label="Forecast">
        </router-link>
      </div>
      <div class="complexButton">
          <div class="button bg-green-1" id="button_56" data-label="Optical"></div>
      </div>
      <div class="elbow bottom-left base bg-green-3 horizontal flexcv"></div>
  </div>
</template>

<script>
export default {
};
</script>
