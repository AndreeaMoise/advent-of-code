const part2 = {};

export const solvePart1 = (entries) => {
	let neighbours = [];
	let sum = 0;
	let number = 0;
	
	for (let i = 0; i < entries.length; i++) {
		for (let j = 0; j < entries[i].length; j++) {
			const ch = parseInt(entries[i][j]);
			
			if (isNaN(ch)) {
				// Character (. or symbol)
				if (number !== 0) {
					const feasibleNeighbours = verifyNeighbours([
						[i - 1, j],
						[i, j ],
						[i + 1, j]
					], entries[i].length, entries.length);
					
					if (feasibleNeighbours.length) {
						neighbours = [...neighbours, ...feasibleNeighbours];
					}
					
					if (surroundedBySymbols(neighbours, entries)) {
						sum += number;
					}
					
					number = 0;
					neighbours = [];
				}
			}
			else {
				// Digit
				const feasibleNeighbours = number === 0
					? verifyNeighbours([
						[i - 1, j],
						[i - 1, j - 1],
						[i, j - 1],
						[i + 1, j - 1],
						[i + 1, j]
					], entries[i].length, entries.length)
					:  verifyNeighbours([
						[i - 1, j],
						[i + 1, j]
					], entries[i].length, entries.length);
				
				if (feasibleNeighbours.length) {
					neighbours = [...neighbours, ...feasibleNeighbours];
				}
				number = number * 10 + ch;
			}
			
			if (j === entries[i].length - 1 && number !== 0) {
				if (surroundedBySymbols(neighbours, entries)) {
					sum += number;
				}
				
				number = 0;
				neighbours = [];
			}
		}
	}
	return sum;
}


export const solvePart2 = (entries) => {
	let neighbours = [];
	let sum = 0;
	let number = 0;
	
	for (let i = 0; i < entries.length; i++) {
		for (let j = 0; j < entries[i].length; j++) {
			const ch = parseInt(entries[i][j]);
			
			if (isNaN(ch)) {
				// Character (. or symbol)
				if (number !== 0) {
					const feasibleNeighbours = verifyNeighbours([
						[i - 1, j],
						[i, j ],
						[i + 1, j]
					], entries[i].length, entries.length);
					
					if (feasibleNeighbours.length) {
						neighbours = [...neighbours, ...feasibleNeighbours];
					}
					
					surroundedBySymbolsPart2(neighbours, entries, number);
					
					number = 0;
					neighbours = [];
				}
			}
			else {
				// Digit
				const feasibleNeighbours = number === 0
					? verifyNeighbours([
						[i - 1, j],
						[i - 1, j - 1],
						[i, j - 1],
						[i + 1, j - 1],
						[i + 1, j]
					], entries[i].length, entries.length)
					:  verifyNeighbours([
						[i - 1, j],
						[i + 1, j]
					], entries[i].length, entries.length);
				
				if (feasibleNeighbours.length) {
					neighbours = [...neighbours, ...feasibleNeighbours];
				}
				number = number * 10 + ch;
			}
			
			if (j === entries[i].length - 1 && number !== 0) {
				surroundedBySymbolsPart2(neighbours, entries, number);
				
				number = 0;
				neighbours = [];
			}
		}
	}
	
	Object.entries(part2).forEach(([ position, star ]) => {
		if (star.length == 2) {
			sum += star[0] * star[1];
		}
	})
	return sum;
}

const verifyNeighbours = (neighbours, cols, rows) => {
	const feasibleNeighbours = [];
	
	neighbours.forEach(([i, j]) => {
		if (positionInBounds(i, j, cols, rows)) {
			feasibleNeighbours.push([i, j]);
		}
	});
	
	return feasibleNeighbours;
}
const positionInBounds = (i, j, cols, rows) => {
	return i >= 0 && i < rows && j >= 0 && j < cols;
}

const isDigit = (ch) => {
	return ch >= '0' && ch <= '9';
}

const surroundedBySymbols = (neighbours, entries) => {
	return neighbours.some(([i, j]) => {
		const el = entries[i][j];
		if (el !== '.'  && isNaN(parseInt(el))) {
			return true;
		}
	});
}

const surroundedBySymbolsPart2 = (neighbours, entries, number) => {
	neighbours.forEach(([i, j]) => {
		const el = entries[i][j];
		
		if (el !== '.'  && isNaN(parseInt(el))) {
			if (el === '*') {
				if (part2[[i, j]]) {
					part2[[i, j]].push(number);
				}
				else {
					part2[[i, j]] = [ number ];
				}
			}
		}
	})
}
