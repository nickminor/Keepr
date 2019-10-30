<template>
  <div class="home">
    <h1>Welcome To Keepr</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <br />
    <hr />
    <div v-if="user.id!=null">
      <div class="create-keep">
        <div class="row offset-1">
          <form @submit="createKeep">
            Keep Name:
            <br />
            <input type="text" name="Keepname" v-model="newkeep.name" value />
            <br />Keep Description:
            <br />
            <input type="text" description="Keepdescription" v-model="newkeep.description" value />
            <br />Keep img url:
            <br />
            <input type="text" img="Keepimgurl" v-model="newkeep.img" value />
            <br />
            <input type="submit" value="Create Keep" />
          </form>
        </div>
      </div>
      <div class="create-vault">
        <div class="row offset-1">
          <form @submit="createVault">
            Vault name:
            <br />
            <input type="text" name="Vaultname" v-model="newvault.name" value />
            <br />Vault description:
            <br />
            <input type="text" name="Vaultname" v-model="newvault.description" value />
            <br />
            <input type="submit" value="Create Vault" />
          </form>
        </div>
      </div>
      <div class="row">
        <!-- <router-link to="{name: 'vaults/id'}"> -->
        <vault v-for="vault in vaults" :key="vault.id" :propvault="vault" />
      </div>
      <!-- </router-link> -->
    </div>
    <div class="row">
      <stack
        :monitor-images-loaded="true"
        :column-min-width="320"
        :gutter-width="8"
        :gutter-height="8"
      >
        <stack-item v-for="keep in keeps" :key="keep.id" :keep="keep">
          <keep :keep="keep" />
        </stack-item>
      </stack>
    </div>
  </div>
</template>

<script>
import { Stack, StackItem } from "vue-stack-grid";

export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    //2.)access the data
    keeps() {
      return this.$store.state.Keeps.keeps;
    },
    vaults() {
      return this.$store.state.Vaults.vaults;
    }
  },
  components: {
    Stack,
    StackItem
  },
  data() {
    return {
      newkeep: {
        name: "",
        description: "",
        img: ""
      },
      newvault: {
        name: "",
        description: ""
      }
    };
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    createKeep() {
      let newkeep = this.newkeep;
      this.$store.dispatch("createKeep", newkeep);
    },
    createVault() {
      let newvault = this.newvault;
      this.$store.dispatch("createVault", newvault);
    }
  },
  mounted() {
    //1.)get data neccessary for home view
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  }
};
</script>