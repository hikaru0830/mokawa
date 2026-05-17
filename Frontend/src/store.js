import { configureStore } from "@reduxjs/toolkit";
import navHeightReducer from "./slices/navHeightSlice";

export const store = configureStore({
  reducer: { // 必要加入 reducer
    navHeight: navHeightReducer
  }
});

export default store;