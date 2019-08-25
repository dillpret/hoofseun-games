<template>
  <div id="app">
    <Navbar/>
    <h1 align="center">Welcome to Hoofseun Games (Under construction)</h1>
    <b-container>
      <b-row>
        <b-col cols="2"></b-col>
        <b-col cols="8">
          <GuestBook/>
        </b-col>
        <b-col cols="2"></b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import ScoreTable from "./components/ScoreTable.vue";
import GuestBook from "./components/GuestBook.vue";
import Navbar from "./components/Navbar.vue";

export default {
  name: "app",
  components: {
    ScoreTable,
    GuestBook,
    Navbar
  }
};
</script>

<style>
</style>
