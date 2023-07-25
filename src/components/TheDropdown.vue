<template>
  <div class="coverSibar" :class="coverSibar">
    <label class="lb-filter" for="" v-show="isHasLabel">{{ label }}</label>
    <span class="clickOutside" @click="ToggleDropdown()">
      <span class="input-light">
        <input 
                :readonly="searchable"
                type="text" 
                autocomplete = "off"
                ref="input"
                :disabled="disabled"
                :class="styleInput"
                :placeholder="placeholder"
                :value="currentValue"
                :tabindex="tabInput"
              />
      </span>
      <i class="fa-solid fa-angle-left"></i>
      <div class="option-dropdown" v-if="isOpenDropdown">
        <ul>
          <li v-for="(item,index) in itemData"
            :key="index"
            :class="[item == currentValue && active]"
            @click="onDropdownValue(item)"
            >{{ item }}
         </li>
        </ul>
      </div>
    </span>
  </div>
</template>

<script>
export default{
    name: "TheDropdown",
    props:{
        //tên class của lớp cart-right
        coverSibar:{
            type:String,
            default:""
        },
        // có label hay không?
        isHasLabel:{
            type:Boolean,
            default: true
        },
        //tên label 
        label:{
            type:String,
            default:"Sắp xếp theo:"
        },
        //TheDropdown chỉ cho đọc
        searchable:{
            type:Boolean,
            default:true
        },
        // TheDropdown có disabled hay không?
        disabled:{
            type:Boolean,
            default:false
        },
        //tên class của input
        styleInput:{
            type:String,
            default:""
        },
        //placeholder của input
        placeholder:{
            type:String,
            default:""
        },
        //tapindex của input
        tabInput:{
            type:String,
            default:""
        },
        // list option can choose
        // itemData:{
        //   type: Array,
        //   default:() =>[
        //     "Mới nhất" , "Giá giảm dần","Giá tăng dần","Sale"
        //   ]
        // }
    },
    emits:["update:modelValue"],
    watch: {
    /**xử lý sự kiện clickOutSide
     * 
     */
    isOpenDropdown(newvalue){
        const me = this;
        if(newvalue == true){
            document.addEventListener('click' , me.clickOutSide);
            document.addEventListener('scroll' , me.srollOutSide);
        } else{
            document.removeEventListener('click', me.clickOutSide)
            document.removeEventListener('scroll', me.srollOutSide)
        }
    },
     // Chuyền currentValue hiện tại lên thằng cha
     currentValue() {
        this.$emit("currentValue", this.currentValue);
    },
  },
    methods:{
      //thực hiện bật tắt dropdown
      ToggleDropdown(){
          this.isOpenDropdown = !this.isOpenDropdown
      },
      // xử lý gán giá trị active khi có giá trị được chọn
      onDropdownValue(itemName){
        this.currentValue = itemName;
        this.ToggleDropdown();
      },
      srollOutSide(){
        // console.log(event);
        if(window.scrollY > 0){
            return this.isOpenDropdown = false;
        }
      },
      clickOutSide(event){
        // console.log(event);
        // console.log("jmaddk");
       if(event.target.closest(`.clickOutside`)) return
        // console.log("sakdjasjd");
       this.isOpenDropdown = false;
    },
    },
    data(){
      return{
        isOpenDropdown: false,
        currentValue : "Mới nhất",
        active: "active",
        itemData :["Mới nhất" , "Giá giảm dần","Giá tăng dần","Sale"]
      }
    }
}
</script>
<style scoped>
.coverSibar{
    display: flex;
    align-items: end;
    justify-content: end;
    margin-top: 20px;
}

.lb-filter {
  font-weight: 700;
  margin-right: 10px;
  margin-bottom: 5px;
  font-size: 14px;
}
.coverSibar > span {
  margin-bottom: 5px;
  position: relative;
  cursor: pointer;
  width: 25%;
}
.coverSibar > span > i {
  transform: rotate(-90deg);
  position: absolute;
  right: 11px;
  top: 3.5px;
}
input {
  border: hidden;
  outline: none;
  font-size: 14px;
  background: white;
}
.input-light {
  padding: 8px 0 8px 5px;
  overflow: hidden;
}
.option-dropdown {
  position: absolute;
    top: 100%;
    background: #fff;
    width: 100%;
    box-shadow: 0px 0px 7px rgb(23 27 42 / 24%);
    border: 1px solid;
    z-index: 100;
}
.dropup{
  display: block;
}
.displNone{
  display: none;
}
.option-dropdown > ul li{
  font-size: 14px;
    padding: 2px 5px;
}
.option-dropdown > ul > li:hover{
  background: #3f81cc;
  color: white;
}
.active{
  color: white;
  background: #3f81cc;
}
</style>
