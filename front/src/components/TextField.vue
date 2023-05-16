<template>
<div :style="{width: block ? '100%' : 'unset'}">
    <span v-if="label" class="label">{{label}}</span>
    <v-text-field 
        :style="{width: block ? '100%' : 'unset'}"
        :disabled="disabled"
        class="TextField" 
        :class="{white}"
        hide-details
        outlined
        @input="change"
        @keydown="$emit('keydown', $event)"
        v-model="inputVal"
        :placeholder="placeholder"
        :type="type"
        clearable
        :block="block"
    >

    </v-text-field>
</div>
</template>

<script>
export default {
  name: "TextField",
  props: {
    label: String,
    placeholder: String,
    white: Boolean,
     value: [String, Number],
     disabled: Boolean,
     password: Boolean,
     block: Boolean,
  },
  data() {
    return {
        pass_hide: true
    }
  },
  methods: {
    change() {
      this.$nextTick(() => {
        this.$emit("change", this.inputVal);
      });
    },
  },
  computed: {
    type() {
        if(this.password) return !this.pass_hide ? '' : 'password'
    },
    inputVal: {
      value: [String, Number],
      get() {
        return this.value;
      },
      set(val) {
        this.$emit("input", val);
      },
    },
  },
};
</script>

<style scoped>
.label {
    display: inline-block;
    margin-bottom: 4px !important;
    font-weight: 300;
    font-size: 16px;
    line-height: 19px;
    color: #000000;
}
.TextField >>> .v-input__icon--clear {
    margin-top: -8px !important;
}
.TextField,
.TextField >>> .v-input__control,
.TextField >>> .v-input__slot,
.TextField >>> input,
.TextField >>> .v-text-field__slot{
    height: 40px !important;
    min-height: 40px !important;
}
.TextField  {
    background: transparent !important;
}

.TextField.white >>> fieldset {
    background: white;
}

.TextField >>> fieldset {
    border-radius: 8px;
    border: unset !important ;
    background: #EEEEEE;
}
</style>
