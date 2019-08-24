<template>
  <div id="guestbook">
    <b-table-simple>
      <b-thead>
        <b-tr>
          <b-th>Name</b-th>
          <b-th>Message</b-th>
        </b-tr>
      </b-thead>
      <b-tbody>
        <b-tr v-for="GuestBookEntry in guestBookEntries" :key="GuestBookEntry.id">
          <b-td>{{ GuestBookEntry.name }}</b-td>
          <b-td>{{ GuestBookEntry.message }}</b-td>
        </b-tr>
      </b-tbody>
    </b-table-simple>
    <p v-if="guestBookEntries.length < 1" class="empty-table">
      No entries.
    </p>

    <b-form>
      <b-form-group label="Your Name">
        <b-form-input v-model="form.name"></b-form-input>
      </b-form-group>

      <b-form-group label="Message">
        <b-form-input v-model="form.message"></b-form-input>
      </b-form-group>

      <b-button pill type="submit" variant="primary">Submit</b-button>
    </b-form>
    

  </div>
</template>

<script>
  export default {
    name: 'guestbook',

    data() {
      return {
        form: {
          name: '',
          message: '',
        },
        guestBookEntries: []
      }
    },
    
    mounted() {
      this.getGuestBookEntries()
    },

    methods: {
      async getGuestBookEntries() {
				try {
					const response = await fetch('http://localhost:5000/api/GuestBookEntries/')
					const data = await response.json()
					this.guestBookEntries = data
				} catch (error) {
					console.error(error)
				}
      },
      
      async addGuestBookEntry(form) {
				try {
					const response = await fetch('http://localhost:5000/api/GuestBookEntries/', {
						method: 'POST',
						body: JSON.stringify(entry),
						headers: { 'Content-type': 'application/json; charset=UTF-8' },
					})
					const data = await response.json()
					this.guestBookEntries = [...this.guestBookEntries, data]
				} catch (error) {
					console.error(error)
				}
			},
    }
  }
</script>

<style scoped></style>