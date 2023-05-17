import ACTION_TYPES from "../actions/actions_type";

const initialState = {
  List: [],
};
const productReducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.FETCH_ALL:
      return {
        ...state,
        List: [...action.payload],
      };
    default:
      return state;
  }
};
export default productReducer;
