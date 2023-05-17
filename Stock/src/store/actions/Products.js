import api from "./api";

import ACTION_TYPES from "./actions_type";

const fetchAll = () => (dispatch) => {
  api
    .productsCRUD()
    .fetchAll()
    .then((res) => {
      console.log(res.data),
        dispatch({
          type: ACTION_TYPES.FETCH_ALL,
          payload: res.data,
        });
    })
    .catch((err) => console.log(err));
};

export default fetchAll;
