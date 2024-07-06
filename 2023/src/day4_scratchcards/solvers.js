export const solvePart1 = (entries) => {
	let points = 0;
	
	entries.forEach(entry => {
		let matches = 0;
		const numbers = {};
		
		const split = entry.split(":")[1].split("|");
		const winningNumbers = split[0].split(" ").filter(s => s !== '');
		const ownNumbers = split[1].split(" ").filter(s => s !== '');
		
		winningNumbers.forEach(n => {
			if (numbers[n]) {
				numbers[n]++;
			}
			else {
				numbers[n] = 1;
			}
		})
		
		ownNumbers.forEach(n => {
			if (numbers[n]) {
				numbers[n]++;
			}
			else {
				numbers[n] = 1;
			}
			
			if (numbers[n] == 2) {
				matches++;
			}
		})
		
		const cardPoints = matches > 0 ? Math.pow(2, matches - 1) : 0;
		
		points += cardPoints;
	});
	
	return points;
}