import { createSlice } from "@reduxjs/toolkit";

export const navHeightSlice = createSlice({
  name: "navHeight",
  initialState: {
    height: 0
  },
  //更新state值
  reducers: { // Actions
    setNavHeight: (state, action) => {
      state.height = Number(action.payload) || 0;
    }
  }
});

export const { setNavHeight } = navHeightSlice.actions;
export default navHeightSlice.reducer;