<template>
  <div id="score-table">
    <p v-if="scoreEntries.length < 1" class="empty-table">
      No scores.
    </p>
    <b-table-simple>
      <b-thead>
        <b-tr>
          <b-th>Name</b-th>
          <b-th>Score</b-th>
        </b-tr>
      </b-thead>
      <b-tbody>
        <b-tr v-for="scoreEntry in scoreEntries" :key="scoreEntry.id">
          <b-td>{{ scoreEntry.name }}</b-td>
          <b-td>{{ scoreEntry.score }}</b-td>
        </b-tr>
      </b-tbody>
    </b-table-simple>
  </div>
</template>

<script>
export default {
  name: "score-table",

  data() {
    return {
      scoreEntries: []
    };
  },

  mounted() {
    this.getScoreEntries();
  },

  methods: {
    async getScoreEntries() {
      try {
        const response = await fetch(
          "http://localhost:5000/api/ScoreEntries/top10"
        );
        const data = await response.json();
        this.scoreEntries = data;
      } catch (error) {
        console.error(error);
      }
    }
  }
};
</script>

<style scoped></style>
