(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this.toString();
    }

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }

        return this.toString();
    }

    String.prototype.isEmpty = function () {
        return this.length === 0;
    }

    String.prototype.truncate = function (n) {
        if (n < 4) {
            return '.'.repeat(n);
        }
        if (this.length <= n) {
            return this.toString();
        }
        if (this.includes(' ')) {
            let words = this.split(' ');
            let result = words[0];
            for (let i = 1; i < words.length; i++) {
                if (result.length + words[i].length + 4 > n) {
                    return result + '...';
                }
                result += ` ${words[i]}`;
            }
        }

        return this.slice(0, n - 3) + '...';
    }

    String.format = function (str, ...params) {
        params.forEach((el, i) => {
            str = str.replace(`{${i}}`, el);
        });
        
        return str;
    }
})()

let str = 'my string';
str = str.ensureStart('my');
console.log(str); // my string
str = str.ensureStart('hello ');
console.log(str); // hello my string
str = str.truncate(16);
console.log(str); // hello my string
str = str.truncate(14);
console.log(str); // hello my...
str = str.truncate(8);
console.log(str); // hello...
str = str.truncate(4);
console.log(str); // hell...
str = str.truncate(2);
console.log(str); // h...
str = String.format('The {0} {1} fox', 'quick', 'brown');
console.log(str); // The quick brown fox