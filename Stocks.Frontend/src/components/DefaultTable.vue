<template>
  <div>
    <b-row>
      <b-col></b-col>
      <b-col cols="8"><b-table striped hover :items="items"></b-table></b-col>
      <b-col></b-col>
    </b-row>
    <b-row>
      <div class="submit-form">
        <div v-if="!submitted">

          <div class="form-group">
            <label for="title">Tracker</label>
            <input
              type="text"
              class="form-control"
              id="Tracker"
              required
              v-model="trackerForStockPurchase"
              name="Tracker"
            />
          </div>

          <div class="form-group">
            <label for="title">Price per share</label>
            <input
              type="number"
              class="form-control"
              id="PricePerShare"
              required
              v-model="pricepershareForStockPurchase"
              name="PricePerShare"
            />
          </div>

          <div class="form-group">
            <label for="title">Amount</label>
            <input
              type="number"
              class="form-control"
              id="Amount"
              required
              v-model="amountForStockPurchase"
              name="Amount"
            />
          </div>

          <div class="form-group">
            <label for="title">Long or short</label>
            <input
              type="text"
              class="form-control"
              id="LongOrShort"
              required
              v-model="longorshortForStockPurchase"
              name="LongOrShort"
            />
          </div>

          <div class="form-group">
            <label for="title">Buy or sell</label>
            <input
              type="text"
              class="form-control"
              id="BuyOrSell"
              required
              v-model="buyorsellForStockPurchase"
              name="BuyOrSell"
            />
          </div>

          <div class="form-group">
            <label for="example-datepicker">Purchase date</label>
            <b-form-datepicker id="example-datepicker" v-model="purchasedateForStockPurchase" class="mb-2"></b-form-datepicker>
          </div>

          <button @click="submitNewStockPurchase" class="btn btn-success">Submit</button>
        </div>

        <!-- <div v-else>
          <h4>You submitted successfully!</h4>
          <button class="btn btn-success" @click="submitNewStockPurchase">Add</button>
        </div> -->
      </div>
    </b-row>
  </div>
</template>

<script lang="ts">
import StockPurchasesDataService from "../services/StockPurchasesDataService";
import axios from 'axios';
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class DefaultTable extends Vue {

  public items: StockPurchase[] = [];

  public trackerForStockPurchase="VUSA";
  public pricepershareForStockPurchase=20;
  public amountForStockPurchase=30;
  public longorshortForStockPurchase="Long";
  public buyorsellForStockPurchase="Buy";
  public purchasedateForStockPurchase = new Date;
  //public purchasedateForStockPurchase= "0001-01-01T00:00:00";

  private newStockPurchase: StockPurchaseWithoutID = {Tracker:"",PricePerShare:0,Amount:0,LongOrShort:"",BuyOrSell:"",PurchaseDate:new Date()};

  private submitted: boolean = false;

  public async created(){
    StockPurchasesDataService.getAll()
      .then((response) => {
        this.items = response.data as StockPurchase[];
        console.log(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  }

  public submitNewStockPurchase():void{
    this.newStockPurchase.Tracker = this.trackerForStockPurchase;
    this.newStockPurchase.PricePerShare = this.pricepershareForStockPurchase;
    this.newStockPurchase.Amount = this.amountForStockPurchase;
    this.newStockPurchase.LongOrShort = this.longorshortForStockPurchase;
    this.newStockPurchase.BuyOrSell = this.buyorsellForStockPurchase;
    this.newStockPurchase.PurchaseDate = this.purchasedateForStockPurchase;
    console.log(this.newStockPurchase);
    StockPurchasesDataService.create(this.newStockPurchase);
  }

}

export interface StockPurchaseWithoutID {
  Tracker: string;
  PricePerShare: number;
  Amount: number;
  LongOrShort: string;
  BuyOrSell: string;
  PurchaseDate: Date;
}

export interface StockPurchase {
  ID: number;
  Tracker: string;
  PricePerShare: number;
  Amount: number;
  LongOrShort: string;
  BuyOrSell: string;
  PurchaseDate: Date;
}

</script>

<style scoped>
.submit-form {
  max-width: 300px;
  margin: auto;
}
</style>