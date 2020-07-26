"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var User = /** @class */ (function () {
    function User(userId, name, email, password, roleId, role, userProjects) {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.password = password;
        this.roleId = roleId;
        this.role = role;
        this.userProjects = userProjects;
    }
    return User;
}());
exports.User = User;
//# sourceMappingURL=user.js.map