<template>
  <div id="app">
    <Navbar />
    <h1 align="center">Welcome to Hoofseun Games</h1>
    <b-img
      width=100
      height=100
      center
      :src="require('@/assets/hoofseun-games-logo.png')"
      fluid
      alt="Responsive image"
    />
    <h1 align="center">Under Construction</h1>
    <b-container>
      <b-row>
        <b-col cols="2"></b-col>
        <b-col cols="8">
          <GuestBook />
        </b-col>
        <b-col cols="2"></b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import GuestBook from "./components/GuestBook.vue";
import Navbar from "./components/Navbar.vue";

export default {
  name: "app",
  components: {
    GuestBook,
    Navbar
  }
};
</script>

<style></style>
