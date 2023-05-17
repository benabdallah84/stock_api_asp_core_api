import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import productReducer from "../store/reducers/productReducer";
import fetchAll from "../store/actions/Products";

const Products = (props) => {
  useEffect(() => [props.fetchAllProducts()], []);
  return <div>from product component</div>;
};
const mapStateToProps = (state) => ({
  productList: state.productReducer.list,
});
const mapActionToProps = {
  fetchAllProducts: fetchAll,
};
export default connect(mapStateToProps, mapActionToProps)(Products);
