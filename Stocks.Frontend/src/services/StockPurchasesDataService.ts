import http from "../http-common";

class TutorialDataService {
  getAll() {
    return http.get("/StockPurchases");
  }

  get(id: string) {
    return http.get(`/StockPurchases/${id}`);
  }

  create(data: any) {
    return http.post("/StockPurchases", data);
  }

  update(id: string, data: any) {
    return http.put(`/StockPurchases/${id}`, data);
  }

  delete(id: string) {
    return http.delete(`/StockPurchases/${id}`);
  }

  deleteAll() {
    return http.delete(`/StockPurchases`);
  }

}

export default new TutorialDataService();