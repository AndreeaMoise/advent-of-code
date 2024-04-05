export const parseEntries = (entries) => {
	const games = {};
	
	entries.forEach(entry => {
		const split = entry.split(": ");
		const gameId = split[0].split(" ")[1];
		const game = [];
		
		split[1].split("; ").forEach(set => {
			const cubes = {};
			
			set.split(", ").forEach(type => {
				const cube = type.split(" ");
				cubes[cube[1]] = cube[0];
			});
			
			game.push(cubes);
		});
		
		games[gameId] = game;
	});
	
	return games;
}

export const solvePart1 = (games) => {
	// only 12 red cubes, 13 green cubes, and 14 blue cubes
	let possibleCount = 0;
	
	for (const [ id, sets ] of Object.entries(games)) {
		let possible = true;
		
		sets.forEach(set => {
			for (const [ type, amount ] of Object.entries(set)) {
				if (
					(type === 'red' && parseInt(amount) > 12) ||
					(type === 'green' && parseInt(amount) > 13) ||
					(type === 'blue' && parseInt(amount) > 14)
				) {
					possible = false;
					break;
				}
			}
		})
		
		if (possible) {
			possibleCount += parseInt(id);
		}
	}
	
	return possibleCount;
}

export const solvePart2 = (games) => {
	let powerSum = 0;
	
	for (const [ id, sets ] of Object.entries(games)) {
		let green = 0;
		let red = 0;
		let blue = 0;
		
		sets.forEach(set => {
			for (const [ type, amount ] of Object.entries(set)) {
				const intAmount = parseInt(amount);
				if (type === 'red' && intAmount > red) {
					red = intAmount;
				}
				else if (type === 'green' && intAmount > green) {
					green = intAmount;
				}
				else if	(type === 'blue' && intAmount > blue) {
					blue = intAmount;
				}
			}
		})
		
		const power = green * red * blue;
		powerSum += power;
	}
	
	return powerSum;
}