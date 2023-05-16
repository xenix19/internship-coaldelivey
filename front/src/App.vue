<template>
  <v-app>
    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  async mounted() {
      if(this.$store.state.access_token && this.$store.state.user)
      var me = await this.$API.ME();
      if(me) {
          this.$store.commit("UpdateUser", me);
          console.log("user updated")
      }else if(me === false) this.$store.commit("Logout");
  },
  data: () => ({
    //
  }),
};
</script>
