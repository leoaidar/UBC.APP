
export const capitalizeFirstLetterOfEachWord = (sentence: string): string => {
    return sentence
        .split(' ')
        .map(word => word.charAt(0).toUpperCase() + word.slice(1))
        .join(' ');
}

export const getFallbackFromName = (name: string): string => {
    const words = name.split(' ');
    const initials = words.slice(0, 2).map(word => word[0].toUpperCase()).join('');
    return initials;
}