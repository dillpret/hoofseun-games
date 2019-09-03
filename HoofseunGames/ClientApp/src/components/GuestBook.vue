<template>
  <div id="guestbook">
    <h2 align="center">Please Sign our Guestbook</h2>

    <b-form @submit.prevent="handleSubmit">
      <b-form-group label="Your Name">
        <b-form-input v-model="form.name"></b-form-input>
      </b-form-group>

      <b-form-group label="Message">
        <b-form-input v-model="form.message"></b-form-input>
      </b-form-group>

      <b-button pill type="submit" variant="primary">Submit</b-button>
    </b-form>

    <b-table-simple>
      <b-thead>
        <b-tr>
          <b-th>Name</b-th>
          <b-th>Message</b-th>
          <b-th>Time</b-th>
        </b-tr>
      </b-thead>
      <b-tbody>
        <b-tr
          v-for="GuestBookEntry in guestBookEntries"
          :key="GuestBookEntry.id"
        >
          <b-td>{{ GuestBookEntry.name }}</b-td>
          <b-td>{{ GuestBookEntry.message }}</b-td>
          <b-td>{{ GuestBookEntry.timeStamp }}</b-td>
        </b-tr>
      </b-tbody>
    </b-table-simple>
    <p v-if="guestBookEntries.length < 1" class="empty-table">
      No entries.
    </p>
  </div>
</template>

<script>
export default {
  name: "guestbook",

  data() {
    return {
      form: {
        name: "",
        message: ""
      },
      submitting: false,
      guestBookEntries: []
    };
  },

  mounted() {
    this.getGuestBookEntries();
  },

  methods: {
    handleSubmit() {
      this.submitting = true;

      this.addGuestBookEntry();

      this.form = {
        name: "",
        message: ""
      };
      this.submitting = false;
    },

    async getGuestBookEntries() {
      try {
        const response = await fetch(
          process.env.VUE_APP_DOMAIN_NAME+"/api/GuestBookEntries/"
        );
        const data = await response.json();
        this.guestBookEntries = data;
      } catch (error) {
        console.error(error);
      }
    },

    async addGuestBookEntry() {
      try {
        const response = await fetch(
          process.env.VUE_APP_DOMAIN_NAME+"/api/GuestBookEntries/",
          {
            method: "POST",
            body: JSON.stringify(this.form),
            headers: { "Content-type": "application/json; charset=UTF-8" }
          }
        );
        const data = await response.json();
        this.guestBookEntries = [...this.guestBookEntries, data];
      } catch (error) {
        console.error(error);
      }
    }
  }
};
</script>

<style scoped></style>
