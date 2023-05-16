<template>
<div :style="{width: block ? '100%' : 'unset'}">
    <span v-if="label" class="label">{{label}}</span>
    <v-select 
        :style="{width: block ? '100%' : 'unset'}"
        class="Select" 
        :class="{white}"
        hide-details
        append-icon="mdi-chevron-down"
        outlined
          :item-text="item_text"
    :item-value="item_value"
    :items="items"
        :nudge-top="50"
        @input="change"
        @keydown="$emit('keydown', $event)"
        v-model="inputVal"
        :placeholder="placeholder"
        :type="type"
        :block="block"
    >

    </v-select>
</div>
</template>

<script>
export default {
  name: "Select",
  props: {
    label: String,
    placeholder: String,
    white: Boolean,
      'item_text': String,
     'item_value': String,
     value: [String, Number],
     password: Boolean,
     items: Array,
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
    font-weight: 600;
    font-size: 16px;
    line-height: 19px;
    color: #000000;
}
.Select >>> .v-input__icon--append {
    margin-top: -8px !important;
}
.Select,
.Select >>> .v-input__control,
.Select >>> .v-input__slot,
.Select >>> input,
.Select >>> .v-text-field__slot{
    height: 40px !important;
    min-height: 40px !important;
}
.Select  {
    background: transparent !important;
}

.Select.white >>> fieldset {
    background: white;
}

.Select >>> fieldset {
    border-radius: 8px;
    border: unset !important ;
    background: #EEEEEE;
}
</style>

<style>
.menuable__content__active {
  margin-top: 48px;
}
</style>
