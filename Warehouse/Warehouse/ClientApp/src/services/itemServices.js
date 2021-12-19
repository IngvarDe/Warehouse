"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ItemServices = void 0;
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
var environment_1 = require("../environments/environment");
//@Injectable({
//  providedIn: 'root'
//})
var ItemServices = /** @class */ (function () {
    function ItemServices(http) {
        this.http = http;
        this.httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': 'application/json; charset=utf-8'
            })
        };
        this.myAppUrl = environment_1.environment.appUrl;
        this.myApiUrl = 'api/Item';
    }
    ItemServices.prototype.getItems = function () {
        var list = this.http.get(this.myAppUrl + this.myApiUrl)
            .pipe(operators_1.retry(1), operators_1.catchError(this.errorHandler));
        return list;
    };
    ItemServices.prototype.getItem = function (id) {
        var edit = this.http.get(this.myAppUrl + this.myApiUrl + '/' + id)
            .pipe(operators_1.retry(1), operators_1.catchError(this.errorHandler));
        return edit;
    };
    ItemServices.prototype.saveItem = function (item) {
        var save = this.http.post(this.myAppUrl + this.myApiUrl, JSON.stringify(item), this.httpOptions)
            .pipe(operators_1.retry(1), operators_1.catchError(this.errorHandler));
        return save;
    };
    ItemServices.prototype.updateItem = function (id, item) {
        var update = this.http.put(this.myAppUrl + this.myApiUrl + id, JSON.stringify(item), this.httpOptions)
            .pipe(operators_1.retry(1), operators_1.catchError(this.errorHandler));
        return update;
    };
    ItemServices.prototype.deleteItem = function (id) {
        var deleteItem = this.http.delete(this.myAppUrl + this.myApiUrl + id)
            .pipe(operators_1.retry(1), operators_1.catchError(this.errorHandler));
        return deleteItem;
    };
    ItemServices.prototype.errorHandler = function (error) {
        var errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        }
        else {
            errorMessage = "Error Code: " + error.status + "\nMessage: " + error.message;
        }
        console.log(errorMessage);
        return rxjs_1.throwError(errorMessage);
    };
    return ItemServices;
}());
exports.ItemServices = ItemServices;
//# sourceMappingURL=itemServices.js.map