const LABELS = [ '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' ];
const LABELS_PART_2 = [ 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' ];
const TYPES = {
	fiveOfAKind: 7,
	fourOfAKind: 6,
	fullHouse: 5,
	threeOfAKind: 4,
	twoPair: 3,
	onePair: 2,
	highCard: 1
};

export const solvePart1 = entries => {
	entries = entries.map(entry => ({
		...entry,
		type: determineType(entry.hand)
	}));
	
	const sorted = entries.toSorted((hand1, hand2) => {
		if (hand1.type !== hand2.type) {
			return hand1.type - hand2.type;
		}
		
		return compareHands(hand1.hand, hand2.hand, LABELS);
	});
	
	let total = 0;
	for (let i = 0; i < sorted.length; i++) {
		total += sorted[i].bid * (i+1);
	}
	
	return total;
};

export const solvePart2 = entries => {
	entries = entries.map(entry => ({
		...entry,
		type: determineTypePart2(entry.hand)
	}));
	
	const sorted = entries.toSorted((hand1, hand2) => {
		if (hand1.type !== hand2.type) {
			return hand1.type - hand2.type;
		}
		
		return compareHands(hand1.hand, hand2.hand, LABELS_PART_2);
	});
	
	let total = 0;
	for (let i = 0; i < sorted.length; i++) {
		total += sorted[i].bid * (i+1);
	}
	
	return total;
	
};

export const parseEntries = entries => {
	const parsedEntries = [];
	
	for (const entry of entries) {
		const split = entry.split(' ');
		
		parsedEntries.push({
			hand: split[0],
			bid: split[1]
		});
	}
	
	return parsedEntries;
};

export const determineType = hand => {
	const cards = {};
	
	for (const card of hand) {
		if (card in cards) {
			cards[card]++;
		}
		else {
			cards[card] = 1;
		}
	}
	
	return determineTypeBasedOnCounts(cards);
};

export const compareHands = (hand1, hand2, labels) => {
	let i = 0;
	while (i < hand1.length) {
		if (hand1[i] === hand2[i]) {
			i++;
		}
		else {
			return labels.indexOf(hand1[i])-labels.indexOf(hand2[i]);
		}
	}
	
	return 0;
};

export const determineTypePart2 = hand => {
	const cards = {};
	let amountOfJ = 0;
	
	for (const card of hand) {
		if (card === 'J') {
			amountOfJ++; 
		}
		
		if (card in cards) {
			cards[card]++;
		}
		else {
			cards[card] = 1;
		}
	}
	
	const typeBasedOnCounts = determineTypeBasedOnCounts(cards);
	if (amountOfJ === 0) {
		return typeBasedOnCounts;
	}
	
	if (amountOfJ === 5) {
		return TYPES.fiveOfAKind;
	}
	
	if (amountOfJ === 4) {
		return TYPES.fiveOfAKind;
	}
	
	if (amountOfJ === 3) {
		if (typeBasedOnCounts === TYPES.fullHouse) {
			return TYPES.fiveOfAKind;
		}
		return TYPES.fourOfAKind;
	}
	
	if (amountOfJ === 2) {
		if (typeBasedOnCounts === TYPES.fullHouse) {
			return TYPES.fiveOfAKind;
		}
		if (typeBasedOnCounts === TYPES.twoPair) {
			return TYPES.fourOfAKind;
		}
		return TYPES.threeOfAKind;
	}
	
	if (amountOfJ === 1) {
		if (typeBasedOnCounts === TYPES.fourOfAKind) {
			return TYPES.fiveOfAKind;
		}
		if (typeBasedOnCounts === TYPES.threeOfAKind) {
			return TYPES.fourOfAKind;
		}
		if (typeBasedOnCounts === TYPES.twoPair) {
			return TYPES.fullHouse;
		}
		if (typeBasedOnCounts === TYPES.onePair) {
			return TYPES.threeOfAKind;
		}
		
		return TYPES.onePair;
	}

	
		// A B C D R -> normal
		
		// JJJJJ: nothing (5J) -> five of a kind
		// JJJJ T: nothing (4J) -> five of a kind
		// JJJ T A: nothing (3J) -> four of a kind
		// JJJ T T: 3J and full house -> five of a kind
		
		// JJ T A B: pair -> three of a kind
		// JJ T A A: two pairs -> four of a kind
		// JJ A A A: full house -> five of a kind
	
		// J A A B C: 1 J and a pair -> three of a kind
		// J A A B B: 1 J and two pairs -> full house
		// J A A A B: 1 J and three of a kind -> four of a kind
		// J A A A A: 1 J and four of a kind -> five of a kind
	
	// J A B C D: nothing (1J) -> pair
};

const determineTypeBasedOnCounts = cards => {
	const keys = Object.keys(cards);
	if (keys.length === 1) {
		return 7;
	}
	
	if (keys.length === 2) {
		if (cards[keys[0]] === 4 || cards[keys[1]] === 4) {
			return 6;
		}
		return 5;
	}
	
	if (keys.length === 3) {
		if (cards[keys[0]] === 3 || cards[keys[1]] === 3 || cards[keys[2]] === 3) {
			return 4;
		}
		return 3;
	}
	
	if (keys.length === 4) {
		return 2;
	}
	
	return 1;
}
