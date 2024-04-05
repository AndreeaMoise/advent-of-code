export const solvePart1 = (entries) => {
	const totalCalibration = entries.reduce((accumulator, currentValue) => {
		const calibration = getCalibration(currentValue);
		
		return accumulator + calibration;
	}, 0);
	
	return totalCalibration;
}

const getCalibration = (entry) => {
	const digits = [ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' ];
	let first = '';
	let last = '';
	 
	for (let i in entry) {
		const ch = entry[i];
		if (digits.includes(ch)) {
			if (first === '') {
				first = ch;
			}
			else {
				last = ch;
			}
		}
	}
	
	if (last === '') {
		last = first;
	}
	const calibration = parseInt(first) * 10 + parseInt(last);
	return calibration;
}

export const solvePart2 = (entries) => {
	const totalCalibration = entries.reduce((accumulator, currentValue) => {
		const calibration = getCalibration(replaceWordsWithDigits(currentValue));
		
		return accumulator + calibration;
	}, 0);
	
	return totalCalibration;
}

const replaceWordsWithDigits = (entry) => {
	let newString = '';
	
	for (let i = 0; i < entry.length; i++) {
		const ch = entry[i];
		
		if (ch === 'o' && entry.substring(i, i + 3) === "one") {
			newString += 1;
		}
		else if (ch === 't' && entry.substring(i, i + 3) === "two") {
			newString += 2;
		}
		else if (ch === 't' && entry.substring(i, i + 5) === "three") {
			newString += 3;
		}
		else if (ch === 'f' && entry.substring(i, i + 4) === "four") {
			newString += 4;
		}
		else if (ch === 'f' && entry.substring(i, i + 4) === "five") {
			newString += 5;
		}
		else if (ch === 's' && entry.substring(i, i + 3) === "six") {
			newString += 6;
		}
		else if (ch === 's' && entry.substring(i, i + 5) === "seven") {
			newString += 7;
		}
		if (ch === 'e' && entry.substring(i, i + 5) === "eight") {
			newString += 8;
		}
		else if (ch === 'n' && entry.substring(i, i + 4) === "nine") {
			newString += 9;
		}
		else {
			newString += ch;
		}
		
	}
	
	return newString;
}