import * as React from "react";
import { Route } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Products from "./components/Products";
import Operations from "./components/Operations";
import Fournisseurs from "./components/Fournisseurs";
import Factures from "./components/Factures";
import Beneficies from "./components/Beneficies";

import "./custom.css";

export default () => (
  <BrowserRouter>
    <Layout>
      <Route exact path="/" component={Home} />
      <Route path="/products" component={Products} />
      <Route path="/operations" component={Operations} />
      <Route path="/factures" component={Factures} />
      <Route path="/fournisseurs" component={Fournisseurs} />
      <Route path="/beneficies" component={Beneficies} />
    </Layout>
  </BrowserRouter>
);
