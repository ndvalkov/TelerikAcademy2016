function solve() {
	return function findPrimes() {
        if (arguments.length !== 2) {
        	throw 'Error';
		}

		let min = +arguments[0];
        let max = +arguments[1];

        if (isNaN(min) || isNaN(max)) {
            throw 'Error';
		}

        let sieve = [];
        let primes = [];

        for (let i = 2; i <= max; ++i) {
            if (!sieve[i]) {
                // i has not been marked -- it is prime
                if (i >= min) {
                    primes.push(i);
                }
                for (let j = i << 1; j <= max; j += i) {
                    sieve[j] = true;
                }
            }
        }

        return primes;
    }
}